using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncIntro
{
    public class AsyncIntro : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly Label label;
        private readonly Button button;
        public AsyncIntro()
        {
            label = new Label
            {
                Location = new Point(10, 20),
                Text = "长度"
            };
            button = new Button
            {
                Location = new Point(10, 50),
                Text = "单击"
            };
            button.Click += DisplayWebSiteLength;//单击事件处理程序
            AutoSize = true;
            Controls.Add(label);
            Controls.Add(button);
        }
        async void DisplayWebSiteLength(object sender, EventArgs e)
        {
            label.Text = "正在获取站点...";
            
            //GetStringAsync将 GET 请求发送到指定 URI 并在异步操作中以字符串的形式返回响应正文
           
            // string text = await client.GetStringAsync("http://www.lzzy.net");

            Task<string> task = client.GetStringAsync("http://www.lzzy.net");
            string text = await task;

            //更新UI
            label.Text = text.Length.ToString();
        }   
    }

}
