using System;

namespace AsyncReturnValueTpye
{
    class Program
    {
        static void Main(string[] args)
        {
            DoAsyncStuffTaskGeneric.CallAsyncMethodReturnTaskGenric();
            DoAsyncStuffTask.CallAsyncMethodReturnTask();
            DoAsyncStuffVoid.CallAsyncMethodReturnVoid();
            DoAsyncStuffValueTask.CallAsyncMethodReturnValueTask();
            Console.WriteLine("主程序");
        }
    }
}
