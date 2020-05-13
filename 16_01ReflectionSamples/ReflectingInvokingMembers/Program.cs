using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectingInvokingMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            GetMember();
            GetMethod();
            GetProperty();

        }
        static void GetMember()
        {
            Console.WriteLine(nameof(GetMember));
            MemberInfo[] members = typeof(Walnut).GetMembers();
            //IEnumerable<MemberInfo> members =
            //    typeof(Walnut).GetTypeInfo().DeclaredMembers;
            foreach (MemberInfo m in members) Console.WriteLine(m);
        }
        static void GetMethod()
        {
            Console.WriteLine("\n"+nameof(GetMethod));
            foreach (MethodInfo m in typeof(Walnut).GetMethods())
                Console.WriteLine(m );
        }

        static void GetProperty()
        {
            Console.WriteLine("\n" + nameof(GetProperty));
            PropertyInfo pi = typeof(Walnut).GetProperty("Title");
            MethodInfo getter = pi.GetGetMethod(); // get_Title
            MethodInfo setter = pi.GetSetMethod(); // set_Title
            MethodInfo[] both = pi.GetAccessors(); // Length==2
            foreach (MethodInfo m in both)
                Console.WriteLine(m);
        }
    }
 

}
