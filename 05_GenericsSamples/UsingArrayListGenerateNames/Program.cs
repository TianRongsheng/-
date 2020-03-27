using System;
using System.Collections;

namespace GeneratingNamesWithArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = GenerateNames();
            PrintNames(names);
        }
        static ArrayList GenerateNames()
        {
            ArrayList names = new ArrayList();
            names.Add("Gamma");//不能约束加入到列表中的元素类型
            names.Add("Vlissides");
            names.Add("Johnson");
            names.Add("Helm");
            return names;
        }
        static void PrintNames(ArrayList names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
