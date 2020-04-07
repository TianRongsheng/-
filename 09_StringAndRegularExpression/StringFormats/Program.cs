using System;
using System.Globalization;
using static System.FormattableString;

namespace StringFormats
{
    public class Program
    {
        static void Main()
        {
            //FormattedStringDemo();
            DateAndNumbers();
            //FormattedStringDemo();
            //MoreFormattableString();
            //UseCustomIFormattable();
            Console.ReadLine();
        }

        static void UseCustomIFormattable()
        {
            var p1 = new Person("Stephanie", "Nagel");
            Console.WriteLine(p1.ToString("L"));
            Console.WriteLine($"{p1:L}");
        }

        public static void FormattedStringDemo()
        {
            DateTime today = DateTime.Today;

            string s = "Hello";
            Console.WriteLine($"{{s}} displays the value of s: {s}");

            string formatString = $"{s}, {{0}}";
            string s2 = "World";

            Console.WriteLine(formatString, s2);
            Console.WriteLine($"{today:d}");//：D可用于清除日期格式后面的具体时间

            var day = new DateTime(2025, 2, 14);
            Console.WriteLine($"{day:d}");
            Console.WriteLine(Invariant($"{day:d}"));//Invariant返回一个结果字符串，其参数可以通过固定区域性的约定格式化。

            string a1 = "a";
            int a2 = 3;
            double a3 = 3.4;
            ShowDetails($"a1: {a1} a2: {a2} a3: {a3}");
        }

        public static void MoreFormattableString()
        {
            int x = 3, y = 4;
            FormattableString s = $"The result of {x} + {y} is {x + y}";
            Console.WriteLine($"format: {s.Format}");
            for (int i = 0; i < s.ArgumentCount; i++)
            {
                Console.WriteLine($"argument {i}: {s.GetArgument(i)}");
            }
        }

        //public static string Invariant(FormattableString s) =>
        //    s.ToString(CultureInfo.InvariantCulture);
        
        public static void ShowDetails(FormattableString s)
        {
            Console.WriteLine($"argument count: {s.ArgumentCount}");//统计
            Console.WriteLine($"format: {s.Format}");
            for (int i = 0; i < s.ArgumentCount; i++)
            {
                Console.WriteLine($"Argument {i}: {s.GetArgument(i)}");//GetArgument：返回这个Argument
            }
        }

        public static void DateAndNumbers()
        {
            var now = new DateTime(2025, 2, 1);
            Console.WriteLine($"{now:D}");
            Console.WriteLine($"{now:d}");
            Console.WriteLine($"{now:dd-MMM-yyyy}");

            int i = 2477;
            Console.WriteLine($"{i:n} {i:e} {i:x} {i:c}");
            double d = 3.1415;
            Console.WriteLine($"{d:###.###}");
            Console.WriteLine($"{d:000.000}");
            Console.WriteLine($"{i:n2}");
        }
    }
}
