using System;

namespace EventThresholdReached
{
    class Program
    {
        static void Main(string[] args)
        {
            //用一个0-9的随机数初始化一个Counter对象，得到的随机数将作为Counter的阈值threshold
            Counter c = new Counter(new Random().Next(10));
            //事件订阅：对象c有一个事件ThresholdReached，
            //当前Program订阅c对象的事件，并且绑定事件处理器c_ThresholdReached;
            //当c.ThresholdReached事件发生时，调用c_ThresholdReached方法
            c.ThresholdReached += c_ThresholdReached;

            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')//Console.ReadKey()获取用户按下的下一个字符或功能键。此处用于判断输出是否为a
            {
                Console.WriteLine("adding one");
                c.Add(2);
            }
        }
        //public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
        static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
            Environment.Exit(0);
        }

    }
}
