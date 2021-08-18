using System;
using System.Collections.Generic;

namespace _4_IncapsulatedAnonFunctionsCalculator
{
    class Program
    {
        private delegate double OperationDelegate(double x, double y);

        private static readonly Dictionary<string, OperationDelegate> _operations = new Dictionary<string, OperationDelegate>
        {
            {"+", delegate(double x, double y) { return x + y; }},
            {"-", delegate(double x, double y) { return x - y; }},
            {"*", delegate(double x, double y) { return x * y; }},
            {"/", delegate(double x, double y) { return x / y; }}
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
