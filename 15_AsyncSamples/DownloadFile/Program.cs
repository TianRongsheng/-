using System;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace DownloadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://www.lzzy.net/upload/main/image/2018/09/12/201809121022432155.jpg";
            var fileName = FileHandler.AsyncDownloadFile(url);
            Console.WriteLine("文件下载成功，文件名称：" + fileName.ToString());
            Console.ReadLine();
        }
    }
}
