using System;

namespace AbstractClassesAbstractMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock msft = new Stock() 
            { 
                Name = "MSFT", 
                PurchasePrice = 20, 
                CurrentPrice = 30,
                SharesOwned = 1000 
            };
            House mansion = new House
            {
                Name = "McMansion",
                PurchasePrice = 300000,
                CurrentPrice = 200000,
                Mortgage = 250000
            };

            Console.WriteLine(msft.NetValue);    
            Console.WriteLine(mansion.NetValue);    

        }
    }
}
