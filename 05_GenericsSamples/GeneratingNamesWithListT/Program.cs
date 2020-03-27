using System;
using System.Collections.Generic;

namespace GeneratingNamesWithListT
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = GenerateNames();
            PrintNames(names);
        }
        static List<string> GenerateNames()
        {
            List<string> names = new List<string>();
            names.Add("Gamma");
            names.Add("Vlissides");
            names.Add("Johnson");
            names.Add("Helm");
            return names;
        }
        static void PrintNames(List<string> names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
