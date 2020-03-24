using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualFunctionMembers
{
    public class Asset
    {
        public string Name;
        public decimal PurchasePrice, CurrentPrice;
        public virtual decimal Liability { get; } = 0;
        /*    public virtual decimal Liability
           { 
                get { return 0; }
           }*/

        //表达式体属性与上等价
        // public virtual decimal Liability => 0; // Expression-bodied property

    }
}
