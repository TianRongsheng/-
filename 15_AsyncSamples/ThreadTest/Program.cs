using System;
using System.Threading;

namespace ThreadTest
{
    //在单核计算机上，操作系统会给每个线程分配一些“时间片”，如20毫秒 
    class Program
    {
        static void Main(string[] args)
        {
            ThreadSample(); //创建线程
             ThreadJoin();     
             Write0();

        }

        static void ThreadSample() 
        {
            //创建一个新线程t，调用Write1（）
            Thread t = new Thread(Write1);
            t.Start(); // running Write1()
            t.Join();


        }
        static void ThreadJoin()
        {
            //创建一个新线程t
            Thread t = new Thread(Write2);
            t.Start(); // running Write2()
            t.Join();//阻塞后续进程直到当前线程结束

        }

         static void Write2()
        {
            for (int i = 0; i < 1000; i++)
            { Console.Write("2");             }
            Thread.Sleep(1000);//休眠
        }
        static void Write0()
        {
            // 主线程重复打印出字符0
            for (int i = 0; i < 1000; i++) Console.Write("0");
        }
            static void Write1()
        {
            for (int i = 0; i < 1000; i++)  Console.Write("1");      
        }
    }
}
