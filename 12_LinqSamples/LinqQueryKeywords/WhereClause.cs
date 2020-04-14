using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqQueryKeywords
{
    public static class WhereClause
    {
        public static void PredicatesExpresion()
        {
            // Data source.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // Create the query with two predicates in where clause.
            var queryLowNums2 =
                from num in numbers
                where num < 5 && num % 2 == 0
                select num;

            var queryLowNums2Test = numbers.Where(n => n < 5 && n % 2 == 0);
            // Execute the query
            foreach (var s in queryLowNums2)
            {
                Console.Write(s.ToString() + " ");
            }
            Console.WriteLine();

            // Create the query with two where clause.
            var queryLowNums3 =
                from num in numbers
                where num < 5
                where num % 2 == 0
                select num;

            var queryLowNums3Test = numbers.Where(n => n < 5 && n % 2 == 0);
            // Execute the query
            foreach (var s in queryLowNums3)
            {
                Console.Write(s.ToString() + " ");
            }
        }
        public static void PredicatesMethod()
        {
            // Data source
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // Create the query with a method call in the where clause.
            // Note: This won't work in LINQ to SQL unless you have a
            // stored procedure that is mapped to a method by this name.
            var queryEvenNums =
                from num in numbers
                where IsEven(num)
                select num;

            var queryEvenNumsTest = numbers.Where(n => IsEven(n));
            // Execute the query.
            foreach (var s in queryEvenNums)
            {
                Console.Write(s.ToString() + " ");
            }
        }

        // Method may be instance method or static method.
        static bool IsEven(int i)
        {
            return i % 2 == 0;
        }
    }
    
}

