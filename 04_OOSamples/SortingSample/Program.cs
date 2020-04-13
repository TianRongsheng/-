using System;

namespace Wrox.ProCSharp.Arrays
{
    class Program
    {
        static void Main()
        {
            //SortInts();
            //Console.WriteLine();
            //SortNames();
            //Console.WriteLine();
            Person[] persons = GetPersons();
            //SortPersons(persons);
            //Console.WriteLine();
            SortUsingPersonComparer(persons);
        }

        private static void SortInts()
        {
            var myInt = new[] { 20, 4, 16, 9, 2 };
            Array.Sort(myInt);
            foreach (var i in myInt) Console.WriteLine($"{ i } ");
        }

        static void SortUsingPersonComparer(Person[] persons)
        {
            Array.Sort(persons,
                new PersonComparer(PersonCompareType.FirstName));

            foreach (Person p in persons)
            {
                Console.WriteLine(p);
            }
        }

        static Person[] GetPersons()
        {
            return new Person[] {
                new Person { FirstName="Damon", LastName="Hill" },
                new Person { FirstName="Niki", LastName="Lauda" },
                new Person { FirstName="Ayrton", LastName="Senna" },
                new Person { FirstName="Graham", LastName="Hill" }
             };
        }

        static void SortPersons(Person[] persons)
        {
            Array.Sort(persons);
            foreach (Person p in persons)
            {
                Console.WriteLine(p);
            }
        }

        static void SortNames()
        {
            string[] names = {
                   "Christina Aguilera",
                   "Shakira",
                   "Beyonce",
                   "Gwen Stefani"
                 };

            Array.Sort(names);

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
