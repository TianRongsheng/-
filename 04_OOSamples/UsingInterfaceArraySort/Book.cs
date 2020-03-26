using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace UsingInterfaceArraySort
{
    public class Book : IComparable
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public Book(string title, double price)
        {
            Title = title;
            Price = price;
        }

        public int CompareTo(object obj)
        {
            Book b = (Book)obj;
            return Convert.ToInt32( (this.Price - b.Price)*100);
        }

    }
}
