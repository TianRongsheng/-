using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqQueryKeywords
{
    public static class FromClause
    {
        public static void LowNums()
        {
            // A simple data source.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // Create the query.
            // lowNums is an IEnumerable<int>
            var lowNums = from num in numbers
                          where num < 5
                          select num;


            var lowNumsTest = numbers.Where(n => n < 5);
            // Execute the query.
            foreach (int i in lowNums)
            {
                Console.Write(i + " ");
            }
        }

        public static void CompoundFromStudent()
        {
            List<Student> students = DataLib.InitializeStudent();
            // Use a compound from to access the inner sequence within each element.
            // Note the similarity to a nested foreach statement.
            var scoreQuery = from student in students
                             from score in student.Scores
                             where score > 90
                             select new { Last = student.LastName, score };

            var scoreQueryTest = students.Select(n => n.Scores.Where(n=> n > 90));//有问题

            // Execute the queries.
            Console.WriteLine("scoreQuery:");
            // Rest the mouse pointer on scoreQuery in the following line to 
            // see its type. The type is IEnumerable<'a>, where 'a is an 
            // anonymous type defined as new {string Last, int score}. That is,
            // each instance of this anonymous type has two members, a string 
            // (Last) and an int (score).
            foreach (var student in scoreQuery)
            {
                Console.WriteLine("{0} Score: {1}", student.Last, student.score);
            }

        }

        public static void CompoundFromXY()
        {
            char[] upperCase = { 'A', 'B', 'C' };
            char[] lowerCase = { 'x', 'y', 'z' };

            var joinQuery1 =
                from upper in upperCase
                from lower in lowerCase
                select new { upper, lower };


            var joinQuery2 =
                from lower in lowerCase
                where lower != 'x'
                from upper in upperCase
                select new { lower, upper };

            // Execute the queries.
            Console.WriteLine("Cross join:");
            // Rest the mouse pointer on joinQuery1 to verify its type.
            foreach (var pair in joinQuery1)
            {
                Console.WriteLine("{0} is matched to {1}", pair.upper, pair.lower);
            }

            Console.WriteLine("Filtered non-equijoin:");
            // Rest the mouse pointer over joinQuery2 to verify its type.
            foreach (var pair in joinQuery2)
            {
                Console.WriteLine("{0} is matched to {1}", pair.lower, pair.upper);
            }
        }


    }
}
