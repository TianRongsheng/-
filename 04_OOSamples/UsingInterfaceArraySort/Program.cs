using System;

namespace UsingInterfaceArraySort
{
    class Program
    {
        static void Main(string[] args)
        {
            var myInt = new[] { 20, 4, 16, 9, 2 };
            Array.Sort(myInt);
            foreach (var i in myInt) Console.Write($"{ i } ");
            Console.WriteLine();

            Book[] books ={
                new Book("C#高级编程",39.52),
                new Book("敏捷开发实战",39.51),
                new Book("用户故事地图",66.88)
            };
            Array.Sort(books);
            foreach (var item in books) Console.WriteLine($"{ item.Title }--{item.Price} ");

        }
    }


}
