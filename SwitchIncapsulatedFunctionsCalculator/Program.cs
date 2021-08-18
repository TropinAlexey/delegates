using System;

namespace SwitchIncapsulatedFunctionsCalculator
{
    class Program
    {
        public static double DoDivision(double x, double y) { return x / y; }
        public static double DoMultiplication(double x, double y) { return x * y; }
        public static double DoSubtraction(double x, double y) { return x - y; }
        public static double DoAddition(double x, double y) { return x + y; }

        public static double PerformOperation(string operation, double x, double y)
        {
            return operation switch
            {
                "+" => DoAddition(x, y),
                "-" => DoSubtraction(x, y),
                "*" => DoMultiplication(x, y),
                "/" => DoDivision(x, y),
                _ => throw new ArgumentException($"Operation {operation} is invalid", nameof(operation))
            };
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter operation:");
            var op = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();

            Console.WriteLine("Enter first operand:");
            var x = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter second operand:");
            var y = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Result is: {PerformOperation(op, x, y)}");
            Console.ReadKey();
        }
    }
}
