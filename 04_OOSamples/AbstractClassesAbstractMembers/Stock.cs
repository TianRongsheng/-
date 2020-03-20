using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClassesAbstractMembers
{
    public class Stock : Asset   // inherits from Asset
    {
        public long SharesOwned;       
        // Override like a virtual method.
        public override decimal NetValue => CurrentPrice * SharesOwned;
    }
}
