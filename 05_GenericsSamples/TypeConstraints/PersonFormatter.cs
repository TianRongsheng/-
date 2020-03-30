using System;
using System.Collections.Generic;
using System.Text;

namespace TypeConstraints
{
    class PersonFormatter : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            Person person = arg as Person;
            switch (format)
            {
                case "CH": return $"{person.LastName} {person.FirstName}";
                case "EN": return $"{person.FirstName} {person.LastName}";
                default: return $"{person.LastName} {person.FirstName}";
            }
        }

      public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
            return null;
        }
    }
}
