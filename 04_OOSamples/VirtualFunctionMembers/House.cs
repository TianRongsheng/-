using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualFunctionMembers
{
    public class House : Asset   // inherits from Asset
    {
        public decimal Mortgage;
        public override decimal Liability { get { return Mortgage; } }
        //等价于
        //public override decimal Liability => Mortgage;
    }
}
