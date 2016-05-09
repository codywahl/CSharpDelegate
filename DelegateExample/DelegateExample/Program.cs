using System;

namespace DelegateExample
{
    internal delegate void Mdelegate();

    internal delegate int Arithmatic(int x, int y);

    internal class Program
    {
        public static void Main(string[] args)
        {
            // Simple delegate example.
            var delegateOne = new Mdelegate(CallbackOne);

            // Another way to create a delegate.
            // Mdelegate delegateOne = CallbackTwo;

            delegateOne();

            // Multi-cast delegate example.
            var delegateTwo = new Mdelegate(CallbackTwo);
            delegateTwo += CallBackThree;

            delegateTwo();

            // Annonymous delegate example.
            Mdelegate delegateThree = delegate
            {
                Console.WriteLine("Annoymous delegate!");
            };

            delegateThree();

            // Delegate as a param
            DoOperation(5, 2, Multiply);
            DoOperation(6, 2, Divide);

            Console.ReadKey();
        }

        private static void CallbackOne()
        {
            Console.WriteLine("Calling callback one");
        }

        private static void CallbackTwo()
        {
            Console.Write("CallbackTwo and... ");
        }

        private static void CallBackThree()
        {
            Console.Write("CallbackThree!" + Environment.NewLine);
        }

        private static void DoOperation(int x, int y, Arithmatic myDelegate)
        {
            int z = myDelegate(x, y);
            Console.WriteLine("Result: " + z);
        }

        private static int Multiply(int x, int y)
        {
            return x * y;
        }

        private static int Divide(int x, int y)
        {
            return x / y;
        }
    }
}