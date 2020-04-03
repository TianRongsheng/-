using System;

namespace Wrox.ProCSharp.Delegates
{
    class Employee
    {
        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        public string Name { get; }
        public decimal Salary { get; }

        public override string ToString() => $"{Name}, {Salary:C}";

        public static bool CompareSalary(Employee e1, Employee e2) =>
          e1.Salary > e2.Salary;

        public static bool CompareName(Employee e1, Employee e2)
        {
            var result = e1.Name.CompareTo(e2.Name);
            return result <= 0 ? true : false;//小于1降序 ==1升序

        }

        public static string Print(Employee emp) => $"员工姓名：{emp.Name}, 工资：{emp.Salary:C}";
    }
}