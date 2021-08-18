using System;
using System.Collections.Generic;

namespace LambdaFunctionsCalculator
{
    class Program
    {
        private static readonly Dictionary<string, Func<double, double, double>> _operations = new Dictionary<string, Func<double, double, double>>
        {
            {"+", (x, y) => x + y},
            {"-", (x, y) => x - y},
            {"*", (x, y) => x * y},
            {"/", (x, y) => x / y}
        };

        public static double PerformOperation(string operation, double x, double y)
        {
            if (!_operations.ContainsKey(operation))
                throw new ArgumentException($"Operation {operation} is invalid", nameof(operation));
            return _operations[operation](x, y);
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter first operand:");
                var x = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter operation:");
                var op = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();

                Console.WriteLine("Enter second operand:");
                var y = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine($"Result is: {PerformOperation(op, x, y)}");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}