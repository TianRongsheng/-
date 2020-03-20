using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClassesAbstractMembers
{
    public abstract class Asset
    {
        public string Name;
        public decimal PurchasePrice, CurrentPrice;
        public abstract decimal NetValue { get; }   // Note empty implementation

    }
}
