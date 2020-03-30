using System;

namespace GeneratingNamesWithArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var names=GenerateNames();
            PrintNames(names);           
        }
        static string[] GenerateNames()
        {
            string[] names = new string[4];//需要预先确定数组的长度
            names[0] = "Gamma";
            names[1] = "Vlissides";
            names[2] = "Johnson";
            names[3] = "Helm";
            return names;
        }
        static void PrintNames(string[] names)
        {         
          
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
