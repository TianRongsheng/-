using DataLib;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Linq;

namespace EnumerableSample
{
    class GroupingSamples
    {
        internal static void Register(CommandLineApplication app)
        {
            app.Command("group", cmd =>
            {
                var methodOption = new CommandOption("-m", CommandOptionType.NoValue);
                var variableOption = new CommandOption("-v", CommandOptionType.NoValue);
                var anonymousOption = new CommandOption("-a", CommandOptionType.NoValue);
                var nestedOption = new CommandOption("-n", CommandOptionType.NoValue);
                var nestedMethodOption = new CommandOption("-nm", CommandOptionType.NoValue);
                cmd.Options.AddRange(new[] { methodOption, variableOption, anonymousOption, nestedOption, nestedMethodOption });
                cmd.Description = "group -[m|v|a|n|nm]";
                cmd.OnExecute(() =>
                {
                    if (methodOption.HasValue())
                    {
                        GroupingWithMethods();
                    }
                    else if (variableOption.HasValue())
                    {
                        GroupingWithVariables();
                    }
                    else if (anonymousOption.HasValue())
                    {
                        GroupingWithAnonymousTypes();
                    }
                    else if (nestedOption.HasValue())
                    {
                        GroupingAndNestedObjects();
                    }
                    else if (nestedMethodOption.HasValue())
                    {
                        GroupingAndNestedObjectsWithMethods();
                    }
                    else
                    {
                        Grouping();
                    }
                    return 0;
                });
            });
        }

        public static void Grouping()
        {
            var countries = from r in Formula1.GetChampions()
                            group r by r.Country into g//group by对每个组执行附加查询操作，可使用上下文关键字 into 指定一个临时标识符。 使用 into 时，必须继续编写该查询，并最终使用一个select 语句或另一个 group 子句结束该查询
                            orderby g.Count() descending, g.Key//descendingorderby 子句中使用 上下文关键字指定排序顺序为从大到小。g.Key表示具有公共键的对象的集合。
                            where g.Count() >= 2
                            select new
                            {
                                Country = g.Key,
                                Count = g.Count()
                            };

            var countries1 = Formula1.GetChampions().GroupBy(r => r.Country).OrderByDescending(r => r.Count())
                .Where(r => r.Count() > 2);
            

            foreach (var item in countries)
            {
                Console.WriteLine($"{item.Country,-10} {item.Count}");
            }

        }

        public static void GroupingWithMethods()
        {
            var countries = Formula1.GetChampions()
              .GroupBy(r => r.Country)
              .OrderByDescending(g => g.Count())
              .ThenBy(g => g.Key)
              .Where(g => g.Count() >= 2)
              .Select(g => new
              {
                  Country = g.Key,
                  Count = g.Count()
              });


            foreach (var item in countries)
            {
                Console.WriteLine($"{item.Country,-10} {item.Count}");
            }

        }

        public static void GroupingWithVariables()
        {
            var countries = from r in Formula1.GetChampions()
                            group r by r.Country into g
                            let count = g.Count()
                            orderby count descending, g.Key
                            where count >= 2
                            select new
                            {
                                Country = g.Key,
                                Count = count
                            };

            foreach (var item in countries)
            {
                Console.WriteLine($"{item.Country,-10} {item.Count}");
            }

        }

        public static void GroupingWithAnonymousTypes()
        {
            var countries = Formula1.GetChampions()
              .GroupBy(r => r.Country)
              .Select(g => new { Group = g, Count = g.Count() })
              .OrderByDescending(g => g.Count)
              .ThenBy(g => g.Group.Key)
              .Where(g => g.Count >= 2)
              .Select(g => new
              {
                  Country = g.Group.Key,
                  g.Count
              });

            foreach (var item in countries)
            {
                Console.WriteLine($"{item.Country,-10} {item.Count}");
            }
        }

        public static void GroupingAndNestedObjects()
        {
            var countries = from r in Formula1.GetChampions()
                            group r by r.Country into g
                            let count = g.Count()
                            orderby count descending, g.Key
                            where count >= 2
                            select new
                            {
                                Country = g.Key,
                                Count = count,
                                Racers = from r1 in g
                                         orderby r1.LastName
                                         select r1.FirstName + " " + r1.LastName
                            };
            foreach (var item in countries)
            {
                Console.WriteLine($"{item.Country,-10} {item.Count}");
                foreach (var name in item.Racers)
                {
                    Console.Write($"{name}; ");
                }
                Console.WriteLine();
            }
        }

        public static void GroupingAndNestedObjectsWithMethods()
        {
            var countries = Formula1.GetChampions()
                .GroupBy(r => r.Country)
                .Select(g => new
                {
                    Group = g,
                    g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(g => g.Count)
                .ThenBy(g => g.Key)
                .Where(g => g.Count >= 2)
                .Select(g => new
                {
                    Country = g.Key,
                    g.Count,
                    Racers = g.Group.OrderBy(r => r.LastName).Select(r => r.FirstName + " " + r.LastName)
                });

            foreach (var item in countries)
            {
                Console.WriteLine($"{item.Country,-10} {item.Count}");
                foreach (var name in item.Racers)
                {
                    Console.Write($"{name}; ");
                }
                Console.WriteLine();
            }
        }
    }
}
