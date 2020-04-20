using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DownloadFile
{
    public static class FileHandler
    {
        /// <summary>
        /// 文件下载目录
        /// </summary>
        private static string _directory = @"F:\作业\Test\";

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url">下载地址</param>
        /// <returns>文件名称</returns>
        public static string DownloadFile(string url)
        {

            string fileName = CreateFileName(url);
            WebClient client = new WebClient();
            client.DownloadFile(url, _directory + fileName);
            return fileName;
        }
        //异步调用
        public static async Task AsyncDownloadFile(string url)
        {
            Console.WriteLine(nameof(DownloadFile));
            //将指定的工作放在线程池中运行，并返回一个任务
            await Task.Run(() =>
            {
                WebClient client = new WebClient();
                string fileName = CreateFileName(url);
                client.DownloadFile(url, _directory + fileName);
                return fileName;
            });
        }
        /// <summary>
        /// 创建文件名称
        /// </summary>
        public static string CreateFileName(string url)
        {
            string fileName;
            string fileExt = url.Substring(url.LastIndexOf(".")).Trim().ToLower();//ToLower返回此字符串转换为小写形式的副本。
            Random rnd = new Random();
            fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + rnd.Next(10, 99).ToString() + fileExt;
            return fileName;
        }

    }
}