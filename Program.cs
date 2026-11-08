using System;

class Program
{
    // Универсальный метод для вычислений. 
    // Он принимает два числа и "поведение" (математическую операцию) в виде делегата.
    static double Calculate(double a, double b, Func<double, double, double> operation)
    {
        return operation(a, b);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("--- Универсальный калькулятор ---");
        
        // Запрос первого числа
        Console.Write("Введите первое число: ");
        if (!double.TryParse(Console.ReadLine(), out double num1))
        {
            Console.WriteLine("Ошибка: введено неверное число.");
            return;
        }

        // Запрос второго числа
        Console.Write("Введите второе число: ");
        if (!double.TryParse(Console.ReadLine(), out double num2))
        {
            Console.WriteLine("Ошибка: введено неверное число.");
            return;
        }

        Console.WriteLine("\n--- Результаты вычислений ---");

        // Вызываем ОДИН И ТОТ ЖЕ метод Calculate, передавая разное поведение через лямбда-выражения
        
        // 1. Сложение
        double sum = Calculate(num1, num2, (x, y) => x + y);
        Console.WriteLine($"Сложение: {sum}");

        // 2. Вычитание
        double difference = Calculate(num1, num2, (x, y) => x - y);
        Console.WriteLine($"Вычитание: {difference}");

        // 3. Умножение
        double product = Calculate(num1, num2, (x, y) => x * y);
        Console.WriteLine($"Умножение: {product}");

        // 4. Деление (с базовой проверкой на ноль внутри лямбды)
        double quotient = Calculate(num1, num2, (x, y) => y != 0 ? x / y : double.NaN);
        
        if (double.IsNaN(quotient))
        {
            Console.WriteLine("Деление: Ошибка (деление на ноль)");
        }
        else
        {
            Console.WriteLine($"Деление: {quotient}");
        }

        // Пример гибкости: можем легко добавить любую операцию без изменения метода Calculate
        double power = Calculate(num1, num2, (x, y) => Math.Pow(x, y));
        Console.WriteLine($"Возведение в степень: {power}");
    }
}
