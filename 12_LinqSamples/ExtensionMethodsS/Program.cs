using System;

namespace ExtensionMethodsS
{

    class Program
    {
        static void Main(string[] args)
        {
           //调用扩展方法 //arg0.Method(arg1, arg2, ...); 
            Console.WriteLine("Perth".IsCapitalized());
            //静态方法调用//StaticClass.Method(arg0, arg1, arg2, ...); 
            Console.WriteLine(ExtensionClass.IsCapitalized("Perth"));
           
            "Seattle".First();
            ExtensionInterface.First("Seattle");
        }
    }
}
