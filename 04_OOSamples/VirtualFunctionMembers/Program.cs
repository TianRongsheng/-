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

            Asset a = mansion;
            decimal d2 = mansion.Liability;      // 250000
            Console.WriteLine(a.Liability) ;
            Console.WriteLine(d2);
        }
    }
}
