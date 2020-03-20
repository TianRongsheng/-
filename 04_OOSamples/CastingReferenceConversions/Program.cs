using System;

namespace CastingReferenceConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            UpCasting();
            DownCasting1();
            DownCasting2();

        }

        private static void UpCasting()
        {
            Stock msft = new Stock()
            {
                Name = "MSFT",
                PurchasePrice = 20,
                CurrentPrice = 30,
                SharesOwned = 1000
            };
            Asset a = msft;                      // 向上转换
            Console.WriteLine(a == msft);       // 输出true
                                                // Console.WriteLine(a.SharesOwned);   // 错误/因为a没有SharesOwned属性
        }

        private static void DownCasting1()
        {
            Stock msft = new Stock()
            {
                Name = "MSFT",
                PurchasePrice = 20,
                CurrentPrice = 30,
                SharesOwned = 1000
            };
            Asset a = msft;
            Stock s = (Stock)a;                  // 向下转换
            Console.WriteLine(s.SharesOwned);   // <正确>
            Console.WriteLine(s == a);          // 输出true
        }
        private static void DownCasting2()
        {
            House h = new House()
            {
                Name = "McMansion",
                PurchasePrice = 300000,
                CurrentPrice = 200000,
                Mortgage = 250000
            };
            Asset a = h;//向上转换永远会成功
            Stock s = (Stock)a;//向下转换出错抛出异常: a不是Stock类型
            Console.WriteLine(s.SharesOwned);

        }

    }
}
