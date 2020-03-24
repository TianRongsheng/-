using System;

namespace InheritFromObject
{
    class  Program
    {
        static void Main()
        {
/*
            int a = 20;
            int b = 30;
            Console.WriteLine(a.ToString()+b.ToString());
            Console.WriteLine(a.Equals(b));
            Console.WriteLine(a==b);
*/

            // Construct a Point object.
            var p1 = new Point(1, 2);

            // Make another Point object that is a copy of the first.
            var p2 = p1.Copy();

            // Make another variable that references the first Point object.
            var p3 = p1;

            // The line below displays false because p1 and p2 refer to two different objects.
            Console.WriteLine(Object.ReferenceEquals(p1, p2));

            // The line below displays true because p1 and p2 refer to two different objects that have the same value.
            Console.WriteLine(Object.Equals(p1, p2));
            Console.WriteLine(p1.Equals(p2));

            // The line below displays true because p1 and p3 refer to one object.
            Console.WriteLine(Object.ReferenceEquals(p1, p3));

            // The line below displays: p1's value is: (1, 2)
            Console.WriteLine($"p1's value is: {p1.ToString()}");
        }
    }

    // This code example produces the following output:
    //
    // False
    // True
    // True
    // p1's value is: (1, 2)
    //
}




