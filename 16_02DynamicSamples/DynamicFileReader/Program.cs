using System;

namespace DynamicFileReader
{
    class Program
    {
        static void Main()
        {
            var helper = new DynamicFileHelper();
            var employeeList = helper.ParseFile("EmployeeList.txt");
            foreach (var employee in employeeList)
            {
                Console.WriteLine($"{employee.姓} {employee.LastName} lives in {employee.City}, {employee.State}.");
            }
            Console.ReadLine();
        }
    }
}
