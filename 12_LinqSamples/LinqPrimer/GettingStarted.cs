using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqPrimer
{
    public static class GettingStarted
    {
        public static void LinqSample()
        {
            //1.数据源
            string[] names = { "Tom", "Dick", "Harry" };

            //2.查询操作
            //查询长度大于4的姓名    
            //方法1.1
            IEnumerable<string> filteredNames1 = System.Linq.Enumerable.Where
            (names, n => n.Length >= 4);

            //Where来自 IEnumerable<TSource>扩展方法
            //方法1.2
            IEnumerable<string> filteredNames2 = names.Where(n => n.Length >= 4);

            //方法1.3
            var filteredNames3 = names.Where(n => n.Length >= 4);

            //方法2
            IEnumerable<string> filteredNames4 = from n in names
                                                 where n.Length >= 4
                                                 select n;

            foreach (string n in filteredNames2)
                Console.WriteLine(n);

            //用两种方式写查询，显示包含字母a的名字


        }

        ///查询从这个集合中查出所有包含字母“a”的元素，
        ///并且将这些元素按字符串长度从小到大排序
        ///再把这些元素转化成大写字母后输出        
        public static void FluentSyntax()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<string> query = names
            .Where(n => n.Contains("a"))//筛选带有a的单词
            .OrderBy(n => n.Length)//以单词长度排序
            .Select(n => n.ToUpper());//将筛选过后的结果用大写来表示
            foreach (string name in query)Console.WriteLine(name);

            //写成查询表达式
        }

        public static void MixedSyntaxQueries()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            int matches = (from n in names where n.Contains("a") select n).Count();//统计字符串中带有a的单词数量
            string first = (from n in names orderby n select n).First();//First返回序列中的第一个元素。
            Console.WriteLine($"{matches},{first}");
        }


        public static void DeferredExecution1() {
            var numbers = new List<int> { 1 };
            IEnumerable<int> query = numbers.Select(n => n * 10); // Build query
            numbers.Add(2); // Sneak in an extra element
            foreach (int n in query)
                Console.Write(n + "|"); // 10|20|
        }
        public static void DeferredExecution2()
        {
 

            IEnumerable<int> query = new int[] { 5, 12, 3 }
                                                     .Where(n => n < 10)
                                                     .OrderBy(n => n)
                                                     .Select(n => n * 10);

            //  等价于
            IEnumerable<int> source = new int[] { 5, 12, 3 };
            var filtered = source.Where(n => n < 10);
            var sorted = filtered.OrderBy(n => n);
            var query1 = sorted.Select(n => n * 10);

            foreach (int n in query) Console.WriteLine(n);
        }
    }
}
