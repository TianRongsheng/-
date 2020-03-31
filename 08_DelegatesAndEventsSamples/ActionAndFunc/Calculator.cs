using System;
using System.Collections.Generic;
using System.Text;

namespace ActionAndFunc
{
    class Calculator
    {
        public void Report()
        {
            Console.WriteLine("I have 3 methods.");
        }
        public double Add(int a, int b)
        {
            int result = a + b;
            return result;
        }

        public double Sub(int a, int b)
        {
            int result = a - b;
            return result;
        }
    }
}
