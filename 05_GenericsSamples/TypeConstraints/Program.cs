using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace TypeConstraints
{
    class Program
    {

        /// <summary>
        /// 静态泛型方法，格式化输出泛型列表。
        /// </summary>
        /// <typeparam name="T">类型T必须是实现IFormattable接口的</typeparam>
        /// <param name="items">需要输出的泛型列表</param>
        /// <param name="format">格式代码</param>
        /// <param name="formatProvider">提供与格式代码对应的具体格式集</param>
        static void PrintItems<T>(List<T> items, string format, IFormatProvider formatProvider) where T : IFormattable
        {
            foreach (T item in items)
            {
                Console.WriteLine(item.ToString(format, formatProvider));
            }
        }

        static void Main()
        {
            PintDecimalList();
            PintSockList();

        }

        private static void PintDecimalList()
        {
            List<decimal> items = new List<decimal>
            {
                1.5m,
                2.3m
            };
            PrintItems(items, "C", CultureInfo.CurrentCulture);
        }

        private static void PintSockList()
        {
            List<Person> items = new List<Person>
            {
                new Person { FirstName="Damon", LastName="Hill" },
                new Person { FirstName="Niki", LastName="Lauda" },
                new Person { FirstName="Ayrton", LastName="Senna" },
                new Person { FirstName="Graham", LastName="Hill" }
            };
            PersonFormatter pf = new PersonFormatter();
            PrintItems(items, "CH", pf);
        }
    }


}
