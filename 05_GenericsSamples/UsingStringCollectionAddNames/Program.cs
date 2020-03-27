using System;
using System.Collections.Specialized;

namespace GeneratingNamesWithStringCollection
{ 
    class Program
    {
        static void Main(string[] args)
        {
            var names = GenerateNames();
            PrintNames(names);
        }
        static StringCollection GenerateNames()
        {
            StringCollection names = new StringCollection();
            names.Add("Gamma");
            names.Add("Vlissides");
            names.Add("Johnson");
            names.Add("Helm");
            return names;
        }
        static void PrintNames(StringCollection names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
