using System;
using System.Collections.Generic;
using System.Text;

namespace EventStock
{
    public class Consumer
    {
        public string Name;

        public Consumer(string name) => Name = name;

        public void Buy(ProductStock ps,int amount)
        {
            ps.Reduce(amount,Name);
        }       
    }
}
