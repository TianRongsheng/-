using System;
using System.Collections.Generic;
using System.Text;

namespace TypeConstraints
{
    public class Person :IFormattable
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            ICustomFormatter customFormatter = formatProvider as ICustomFormatter;
            if (customFormatter == null) return this.ToString();
            return customFormatter.Format(format, this, null);
        }
    }
}
