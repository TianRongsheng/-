using System;
using System.Collections.Generic;
using System.Text;

namespace UsingInterfaceExamplePrintInfo
{
    class CB:IInfo
    {
        public string First;
        public string Last;
        public double PersonsAge;

        public string GetAge() => PersonsAge.ToString();


        public string GetName() => $"{First} {Last}";
 
    }
}
