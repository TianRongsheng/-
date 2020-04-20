using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DownLoadString
{
    class MyDownloadString
    {

        // 创建Stopwatch类实例用于测量代码中不同任务的执行时间。

        Stopwatch sw = new Stopwatch();
        public void DoRun()
        {
            const int LargeNumber = 6000000;
            sw.Start();
           
            //调用同步方法
            //int t1 = CountCharacters(1, "http://www.microsoft.com");
            //int t2 = CountCharacters(2, "http://www.lzzy.net");
            
            //调用异步方法
            Task<int> t1 = CountCharactersAsync(1, "http://www.microsoft.com");
            Task<int> t2 = CountCharactersAsync(2, "http://www.lzzy.net");

            CountToALargeNumber(1, LargeNumber);
            CountToALargeNumber(2, LargeNumber);
            CountToALargeNumber(3, LargeNumber);
            CountToALargeNumber(4, LargeNumber);

            
            //Console.WriteLine($"Chars in http://www.microsoft.com : { t1 }");
            //Console.WriteLine($"Chars in http://www.lzzy.net: { t2 }");

            //获得异步调用结果
            Console.WriteLine($"Chars in http://www.microsoft.com : { t1.Result }");
            Console.WriteLine($"Chars in http://www.lzzy.net: { t2.Result }");
        }

        /// <summary>
        /// 同步方法
        /// 下载某网站的内容，并返回该网站包含的字符数。
        /// 网站由URL字符串指定
        /// </summary>
        private int CountCharacters(int id, string uriString)
        {
            WebClient wc1 = new WebClient();
            Console.WriteLine("Starting call {0} : {1, 4:N0} ms",
            id, sw.Elapsed.TotalMilliseconds);
            string result = wc1.DownloadString(new Uri(uriString));
            Console.WriteLine(" Call {0} completed: {1, 4:N0} ms",
            id, sw.Elapsed.TotalMilliseconds);
            return result.Length;
        }


        /// <summary>
        /// 异步方法
        /// 下载某网站的内容，并返回该网站包含的字符数。
        /// </summary>
        /// <param name="id">任务编号</param>
        /// <param name="site">站点</param>
        /// <returns></returns>
        private async Task<int> CountCharactersAsync(int id, string site)
        {
            WebClient wc = new WebClient();
            Console.WriteLine("Starting call {0} : {1, 4:N0} ms",
            id, sw.Elapsed.TotalMilliseconds);
            //异步操作
            string result = await wc.DownloadStringTaskAsync(new Uri(site));
            Console.WriteLine(" Call {0} completed: {1, 4:N0} ms",
            id, sw.Elapsed.TotalMilliseconds);
            return result.Length;
        }

        /// <summary>
        ///  该方法循环指定次数用于消耗时间。
        /// </summary>
        private void CountToALargeNumber(int id, int value)
        {
            for (long i = 0; i < value; i++) ;
            Console.WriteLine(" End counting {0} : {1, 4:N0} ms",
            id, sw.Elapsed.TotalMilliseconds);
        }
    }
}
