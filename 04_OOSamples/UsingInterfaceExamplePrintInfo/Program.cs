using System;

namespace UsingInterfaceExamplePrintInfo
{
    class Program
    {
        static void Main(string[] args)
        {

            CA a = new CA(){ Name = "John Doe",Age = 35};
            CB b = new CB() { First = "Jane", Last = "Doe", PersonsAge = 33 };
            PrintInfo(a);
            PrintInfo(b);
        }
        static void PrintInfo(IInfo item)
        {
            Console.WriteLine($"Name: { item.GetName() }, Age: { item.GetAge() }");
        }
    }
}
