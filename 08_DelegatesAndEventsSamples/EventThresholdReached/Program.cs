using System;

namespace EventThresholdReached
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter c = new Counter(new Random().Next(10));
            c.ThresholdReached += c_ThresholdReached;

            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')//Console.ReadKey()获取用户按下的下一个字符或功能键。此处用于判断输出是否为a
            {
                Console.WriteLine("adding one");
                c.Add(1);
            }
        }
        static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
          //  Environment.Exit(0);
        }

    }
}
