using System;
using System.Collections;

namespace IEnumerableAndIEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Hello";
            IEnumerator rator = s.GetEnumerator();
            while (rator.MoveNext())
            {
                char c = (char)rator.Current;
                Console.Write(c + ".");
            }

            // 由于String类实现IEnumerable，故我们可以使用foreach迭代
            foreach (char c in s)  Console.Write(c + ".");

            Console.WriteLine();

            // 由于Array类实现IEnumerable，故我们可以使用foreach迭代
            int[] data = { 1, 2, 3 };
            foreach (int d in data) Console.Write(d + ".");

        }
    }
}
