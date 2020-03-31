using System;
using System.Collections.Generic;

namespace CopyingElements
{
    class Program
    {
        public static List<T> CopyAtMost<T>(List<T> input, int maxElements)
        {
            int actualCount = Math.Min(input.Count, maxElements);
            List<T> ret = new List<T>(actualCount);
            for (int i = 0; i < actualCount; i++)
            {
                ret.Add(input[i]);
            }
            return ret;
        }
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            numbers.Add(5);
            numbers.Add(10);
            numbers.Add(20);
            List<Student> S = new List<Student>
            {
                new Student{ Name=1,Age=10},
                new Student{ Name=2,Age=20},
                new Student{ Name=3,Age=30}
            };
            List<Student> firstTwo = CopyAtMost(S, 3);
            //Console.WriteLine(firstTwo.);
            Console.WriteLine(firstTwo.Count);
        }
        class Student
        {
            public int Name { set; get; }
            public int Age { set; get; }
        }

    }
}
