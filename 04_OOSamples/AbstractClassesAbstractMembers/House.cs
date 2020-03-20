using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClassesAbstractMembers
{
    public class House : Asset   // inherits from Asset
    {
        
        public decimal Mortgage;
        public override decimal NetValue
        {
            get { return CurrentPrice - Mortgage; }
        }

    }
}
