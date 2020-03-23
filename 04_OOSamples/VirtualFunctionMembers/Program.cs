using System;

namespace VirtualFunctionMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            House mansion = new House
            {
                Name = "McMansion",
                PurchasePrice = 300000,
                CurrentPrice = 200000,
                Mortgage = 250000
            };

            Stock msft = new Stock()
            {
                Name = "MSFT",
                PurchasePrice = 20,
                CurrentPrice = 30,
                SharesOwned = 1000
            };

            /*  Asset a = mansion;
              decimal d2 = mansion.Liability;      // 250000
              Console.WriteLine(a.Liability);
              Console.WriteLine(d2);*/
            Asset a = msft;
            Console.WriteLine(a.Liability);
        }
    }
}
