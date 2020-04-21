using System;
using System.Reflection;

namespace TypeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(String);
           
            MethodInfo substr = t.GetMethod(
                "Substring", new Type[] { typeof(int), typeof(int) });

            Object result =substr.Invoke(
                "Hello, World!", new Object[] { 7, 5 });
          
            Console.WriteLine("{0} returned \"{1}\".", substr, result);
        }
    }
}
