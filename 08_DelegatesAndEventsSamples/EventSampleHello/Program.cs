using System;

namespace EventSampleHello
{
    class Program
    {
        static void Main(string[] args)
        {
            Message m = new Message();
            m.SampleEvent += OrderMessage;
            m.onWriteHello();
            
        }
        static void OrderMessage(object sender, SampleEventArgs e) 
        {
            Console.WriteLine(e.Text);
        }
    }
}
