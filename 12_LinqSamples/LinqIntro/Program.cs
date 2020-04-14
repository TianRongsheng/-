using DataLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LinqIntro
{
    class Program
    {
        static void Main()
        {

            //LINQ查询
            LINQQuery();
            //扩展方法
            ExtensionMethods();
            //延迟查询
            DeferredQuery();
        }

        static void DeferredQuery()
        {
            var names = new List<string> { "Nino", "Alberto", "Juan", "Mike", "Phil" };

            var namesWithJ = from n in names
                             where n.StartsWith("J")
                             orderby n
                             select n;

            Console.WriteLine("First iteration");
            foreach (string name in namesWithJ)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            names.Add("John");
            names.Add("Jim");
            names.Add("Jack");
            names.Add("Denny");

            Console.WriteLine("Second iteration");
            foreach (string name in namesWithJ)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }


        static void ExtensionMethods()
        {
            var champions = new List<Racer>(Formula1.GetChampions());
            IEnumerable<Racer> brazilChampions =
                champions.Where(r => r.Country == "Brazil")
                    .OrderByDescending(r => r.Wins)
                    .Select(r => r);

            foreach (Racer r in brazilChampions)
            {
                Console.WriteLine($"{r:A}");
            }
            Console.WriteLine();
        }


        static void LINQQuery()
        {
            //LINQ查询
            //查询来自巴西的所有世界冠军，并按照夺冠次数排序。
            //可以使用List<T> 类的方法，如FindAll0和Sort方法。
            //也可以使用LINQ的语

            var query = from r in Formula1.GetChampions()
                        where r.Country == "Brazil"
                        orderby r.Wins descending
                        select r;

            foreach (var r in query)
            {
                Console.WriteLine($"{r:A}");
            }
            Console.WriteLine();
        }
    }
}
