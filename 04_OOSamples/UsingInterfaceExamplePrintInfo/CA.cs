using System;
using System.Collections.Generic;
using System.Text;

namespace UsingInterfaceExamplePrintInfo
{
    class CA:IInfo
    {
        public string Name;
        public int Age;

        public string GetAge() => Age.ToString();

        public string GetName() => Name.ToString();
  
    }


}
