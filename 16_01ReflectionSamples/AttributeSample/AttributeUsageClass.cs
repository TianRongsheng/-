using System;
using System.Collections.Generic;
using System.Text;

namespace AttributeSample
{
   public class AttributeUsageClass
    {
        public string Title { get; set; }
        public int Number { get; set; }

        public AttributeUsageClass(string title,int number)
        {
            Title = title;
            Number = number;
        }

        public void Print() 
        {
            Console.WriteLine($"{Title}:{Number}");
        }
    }
}
