using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqQueryKeywords
{
    // group 子句返回一个 IGrouping<TKey, TElement> 对象序列
    //这些对象包含零个或更多与该组的键值匹配的项。
    public static class GroupClause
    {
        static List<Student> students = DataLib.InitializeStudent();

        public static void GroupByChar()
        {     
            // Group students by the first letter of their last name
            // Query variable is an IEnumerable<IGrouping<char, Student>>
            var studentQuery =
                from student in students
                group student by student.LastName[0] into g
                orderby g.Key
                select g;
            // Iterate group items with a nested foreach. This IGrouping encapsulates
            // a sequence of Student objects, and a Key of type char.
            // For convenience, var can also be used in the foreach statement.
            foreach (IGrouping<char, Student> studentGroup in studentQuery)
            {
                Console.WriteLine(studentGroup.Key);
                // Explicit type for student could also be used here.
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}", student.LastName, student.FirstName);
                }
            }
        }

        public static void GroupByBool() 
        {
            // Group by true or false.
            // Query variable is an IEnumerable<IGrouping<bool, Student>>
            var booleanGroupQuery =
                from student in students
                group student by student.Scores.Average() >= 80; //pass or fail!

            // Execute the query and access items in each group
            foreach (var studentGroup in booleanGroupQuery)
            {
                Console.WriteLine(studentGroup.Key == true ? "High averages" : "Low averages");
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}:{2}", student.LastName, student.FirstName, student.Scores.Average());
                }
            }
        }
    }
}
