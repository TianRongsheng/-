using System;
using System.Collections.Generic;
using System.Reflection;

namespace TypeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //TypesName();
            //GetInterfaces();
            //InstantiatingTypes1();
            InvokeMethod();
            InstantiatingTypes1();
            InstantiatingTypes2();
        }
        static void InvokeMethod() 
        {
            Type t = typeof(String);
            MethodInfo substr = t.GetMethod(
                "Substring", new Type[] { typeof(int), typeof(int) });

            string s = "Hello, World!";
            ////字符串实例方法调用Substring
            //var r1 = s.Substring(7, 5);
          //  Console.WriteLine(r1);
            //反射机制，获取方法成员信息，invoke调用
            Object result = substr.Invoke(s, new Object[] { 7, 5 });     
            Console.WriteLine("{0} \n{1}", substr, result);
        }
        static void GetInterfaces()
        {
            foreach (Type iType in typeof(Guid).GetInterfaces())
                Console.WriteLine(iType.Name);
           
            
            //IFormattable
            //IComparable
            //IComparable'1
            //IEquatable'1
        }

        static void TypesName() 
        {
            Type t = typeof(System.Text.StringBuilder);
            Console.WriteLine(t.Namespace); // System.Text
            Console.WriteLine(t.Name); // StringBuilder
            Console.WriteLine(t.FullName); // System.Text.StringBuilder

            Type t1 = typeof(Dictionary<,>); // Unbound
            Console.WriteLine(t1.Name); // Dictionary'2
            Console.WriteLine(t1.FullName); // System.Collections.Generic.Dictionary'2

            Type t3 = DateTime.Now.GetType();
            Type t4 = 3.GetType();
            Type t5 = "abc".GetType();

            Type base1 = typeof(System.String).BaseType;
            Type base2 = typeof(System.IO.FileStream).BaseType;
            Console.WriteLine(base1.Name); // Object
            Console.WriteLine(base2.Name); // Stream
        }

        static void InstantiatingTypes1()
        {
          
            int i = (int)Activator.CreateInstance(typeof(int), 3);
            DateTime dt = (DateTime)Activator.CreateInstance(typeof(DateTime),
            2000, 1, 1);
            Console.WriteLine(i);
            Console.WriteLine(dt.ToString());
        }
        static void InstantiatingTypes2()
        {
            Delegate staticD = Delegate.CreateDelegate (typeof(IntFunc), typeof(Program), "Square");
            Delegate instanceD = Delegate.CreateDelegate(typeof(IntFunc), new Program(), "Cube");
            Console.WriteLine(staticD.DynamicInvoke(3)); // 9
            Console.WriteLine(instanceD.DynamicInvoke(3)); // 27
        }
        delegate int IntFunc(int x);
        static int Square(int x) { return x * x; } // Static method
        int Cube(int x) { return x * x * x; } // Instance method
    }
}
