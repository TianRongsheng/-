using System;


namespace ReferencesPolymorphic
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

            Display1(msft);
            Display1(mansion);
            //Display(new Asset());
        }
        public static void Display1(Asset asset)
        {
            System.Console.WriteLine(asset.Name);
        }

        public static void Display2(House house)         // Will not accept Asset
        {
            System.Console.WriteLine(house.Mortgage);
        }

    }

}
