using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethodsS
{
    public static class ExtensionInterface { 
    public static T First<T>(this IEnumerable<T> sequence)
    {
        foreach (T element in sequence)
            return element;
        throw new InvalidOperationException("No elements!");
    }
    }
}
