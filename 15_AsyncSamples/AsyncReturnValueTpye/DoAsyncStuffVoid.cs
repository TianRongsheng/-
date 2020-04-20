using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncReturnValueTpye
{
    static class DoAsyncStuffVoid
    {
        private static int GetSum(int x, int y)
        {           
            return x + y;
        }
        private static async void CalculateSumAsync(int x, int y)
        {
            int sum = await Task.Run(() => GetSum(x, y));
           
            Console.WriteLine($"void: {sum}");
        }

        static public void CallAsyncMethodReturnVoid()
        {
            Console.WriteLine("调用返回值为void的异步方法");
            CalculateSumAsync(5, 6);//调用并遗忘
            //（如有需要） 此处可以做其它事情 ... 
            Console.WriteLine("其它处理3");
        }

    }
}