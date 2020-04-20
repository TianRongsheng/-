using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncReturnValueTpye
{
     static  class DoAsyncStuffTaskGeneric
    {
        private static int GetSum(int x, int y)
        {
            return x + y;
        }
        private static async Task<int> CalculateSumAsync(int x, int y)
        {
            int sum = await Task.Run(() => GetSum(x, y));
            return sum;
        }

       static public void CallAsyncMethodReturnTaskGenric()
        {
            Console.WriteLine("调用返回值为Task<T>的异步方法");
            Task<int> value =CalculateSumAsync(5, 6);
            //（如有需要） 此处可以做其它事情 ...          
            Console.WriteLine($"Task<T>: {value.Result}" );
            Console.WriteLine("其它处理1");
        }

    }
}
