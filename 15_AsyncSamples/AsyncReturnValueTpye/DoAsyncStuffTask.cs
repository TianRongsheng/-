using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncReturnValueTpye
{
    static class DoAsyncStuffTask
    {
        private static int GetSum(int x, int y)
        {
            return x + y;
        }
        private static async Task CalculateSumAsync(int x, int y)
        {
            int sum = await Task.Run(() => GetSum(x, y));
            Console.WriteLine($"Task: {sum}");
        }

        static public void CallAsyncMethodReturnTask()
        {
            Console.WriteLine("调用返回值为Task的异步方法");
            Task task = CalculateSumAsync(5, 6);
            //（如有需要） 此处可以做其它事情 ...
            task.Wait();        
            Console.WriteLine("其它处理2");
        }

    }
}
