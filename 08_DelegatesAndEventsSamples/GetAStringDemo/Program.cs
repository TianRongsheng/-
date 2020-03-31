using System;

namespace GetAStringDemo
{
    //定义委托
    //delegate 返回值类型 委托名（参数列表）
     public  delegate string GetAString();
    class Program
    {
        //所有返回字符串的无参方法都可以跟下面的委托变量（实例）匹配
   
        static void Main()
        {
            int x = 40;
            //生成委托变量实例firstStringMethod
            //次候firstStringMethod作用等价于x.x.ToString
            GetAString firstStringMethod = new GetAString(x.ToString); 
            Console.WriteLine($"String is {firstStringMethod()}");
            // Console.WriteLine("String is {0}", x.ToString());

            var balance = new Currency(34, 50);
            // firstStringMethod references an instance method
            firstStringMethod = balance.ToString;
            Console.WriteLine($"String is {firstStringMethod()}");

            // firstStringMethod references a static method
            firstStringMethod = new GetAString(Currency.GetCurrencyUnit);
            Console.WriteLine($"String is {firstStringMethod()}");
        }
    }
}
