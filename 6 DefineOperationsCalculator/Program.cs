using Microsoft.CodeAnalysis.CSharp.Scripting;
using System;
using System.Collections.Generic;

namespace _6_DefineOperationsCalculator
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

        public static void DefineOperation(string operation, Func<double, double, double> body)
        {
            if (_operations.ContainsKey(operation))
                throw new ArgumentException($"Operation {operation} already exists", nameof(operation));
            _operations.Add(operation, body);
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter first operand:");
                var x = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter operation:");
                var op = Console.ReadLine();

                if (op?.ToLower() == "define")
                {
                    Console.WriteLine("Enter new operation name:");
                    var operationName = Console.ReadLine();
                    Console.WriteLine("Define operation:");
                    var body = Console.ReadLine();
                    DefineOperation(operationName, CSharpScript.EvaluateAsync<Func<double, double, double>>(body).GetAwaiter().GetResult());

                    Console.WriteLine("Enter second operand:");
                    var y = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine($"Result is: {PerformOperation(operationName, x, y)}");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Enter second operand:");
                    var y = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine($"Result is: {PerformOperation(op, x, y)}");
                    Console.ReadKey();
                }
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
