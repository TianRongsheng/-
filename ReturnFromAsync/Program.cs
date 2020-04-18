using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReturnFromAsync
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        //异步方法
        static async Task<int> GetPageLengthAsync(string url)
        {
            //异步操作 client.GetStringAsync(url);
            //异步方法和异步操作之间的边界为Task<string>。
            Task<string> fetchTextTask = client.GetStringAsync(url);
            int length = (await fetchTextTask).Length;
            return length;
        }

        //调用方法
        static void PrintPageLength()
        {
            //调用方法和异步方法之间的边界为Task<int>;
            Task<int> lengthTask =
               GetPageLengthAsync("http://www.lzzy.net");
            Console.WriteLine(lengthTask.Result);
        }

        static void Main()
        {
            PrintPageLength();
        }
    }
}
