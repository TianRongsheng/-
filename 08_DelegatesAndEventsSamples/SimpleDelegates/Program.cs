using System;

namespace Wrox.ProCSharp.Delegates
{
    delegate double DoubleOp(double x);

    class Program
    {
        static void Main()
        {
            //委托数组operations
            //operations[0]= MathOperations.MultiplyByTwo
            //operations[1]=MathOperations.Square
            DoubleOp[] operations =
            {
                MathOperations.MultiplyByTwo,
                MathOperations.Square
            };
           
                   for (int i = 0; i < operations.Length; i++)
                   {
                       Console.WriteLine($"使用 operations[{i}]:");
                       ProcessAndDisplayNumber(operations[i], 2.0);
                       ProcessAndDisplayNumber(operations[i], 7.94);
                       ProcessAndDisplayNumber(operations[i], 1.414);
                       Console.WriteLine();
                   }
                
         
        }

        static void ProcessAndDisplayNumber(DoubleOp action, double value) =>
            Console.WriteLine($"原始数据：{value}, 对数据处理后： {action(value)}");
    
        /* static void ProcessAndDisplayNumber(DoubleOp action, double value)
        {
                 Console.WriteLine($"原始数据：{value}, 对数据处理后： {action(value)}");
        }*/

    }
}
