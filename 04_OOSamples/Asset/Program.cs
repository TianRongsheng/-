using System;

namespace InheritanceBaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock msft = new Stock()
            { Name = "MSFT", PurchasePrice = 20, CurrentPrice = 30, SharesOwned = 1000 };

            House mansion = new House
            {
                Name = "McMansion",
                PurchasePrice = 300000,
                CurrentPrice = 200000,
                Mortgage = 250000
            };

            Console.WriteLine(msft.Name);           // MSFT
            Console.WriteLine(mansion.Name);        // McMansion

            Console.WriteLine(msft.SharesOwned);    // 1000
            Console.WriteLine(mansion.Mortgage);    // 250000
        }
    }
}
