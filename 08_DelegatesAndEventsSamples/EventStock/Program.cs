using System;
using System.Threading;

namespace EventStock
{
   public class Program
    {
        static void Main(string[] args)
        {
            ProductStock ps = new ProductStock("螺蛳粉", 3);
            Console.WriteLine($"{DateTime.Now.ToShortDateString()}{ps.Name}库存{ps.GetInventory()}");
                       
            Consumer cm1 = new Consumer("张三");
            cm1.Buy(ps, 1);
            Thread.Sleep(2000);
          
            Consumer cm2 = new Consumer("李四");           
            cm2.Buy(ps, 1);
            
            Thread.Sleep(2000);
            Consumer cm3 = new Consumer("王五");
            cm3.Buy(ps, 1);

        }


    }
}
