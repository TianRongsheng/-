using System;
using System.Collections.Generic;
using System.Text;

namespace WithDI
{
    public class SerivceGreetCn : ISerivceGreetCn
    {
        public string Serivce(string name)
        {
            return $"你好呀,{name}";
        }
    }
}
