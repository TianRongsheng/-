using System;

namespace Wrox.ProCSharp.Delegates
{
    class Program
    {
        static void Main()
        {
            Employee[] employees =
            {
                new Employee("Bugs Bunny", 20000),
                new Employee("Elmer Fudd", 10000),
                new Employee("Daffy Duck", 25000),
                new Employee("Wile Coyote", 1000000.38m),
                new Employee("Foghorn Leghorn", 23000),
                new Employee("RoadRunner", 50000)
            };

            BubbleSorter.Sort<Employee>(employees, Employee.CompareSalary);


            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee);
            //}

            BubbleSorter.Export(employees, Employee.Print);
            Console.WriteLine("------------NAME------------");

            BubbleSorter.Sort<Employee>(employees, Employee.CompareName);

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee);
            //}
            BubbleSorter.Export(employees, Employee.Print);
        }
    }
}
