using System;

public delegate void Del(string message);

namespace _0_Sandbox
{
    class Program
    {
        // Create a method for a delegate.
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            // Instantiate the delegate.
            Del handler = DelegateMethod;

            // Call the delegate.
            handler("Hello World");
        }
    }
}
