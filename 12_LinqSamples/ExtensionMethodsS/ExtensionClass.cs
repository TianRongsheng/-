using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethodsS
{
 public static   class ExtensionClass
    {
        public static bool IsCapitalized(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return char.IsUpper(s[0]);
        }
        public static string Getstar(this string a,int b)
        {
            for (int n = 0; n < b; n++)
            {
                a += "*";
            }
            return a;
        }
    }
}
