using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Reflection;

namespace ClientApp
{
    class Program
    {
        private const string CalculatorTypeName = "CalculatorLib.Calculator";

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                ShowUsage();
                return;
            }
            UsingReflection(args[0]);
            UsingReflectionWithDynamic(args[0]);
        }

        private static void ShowUsage()
        {
            Console.WriteLine($"用法: dotnet run 绝对路径");
            Console.WriteLine();
            Console.WriteLine("将CalculatorLib.dll复制到外接程序目录");
            Console.WriteLine("并在启动应用程序加载库时传递此目录的绝对路径");
        }

        private static void UsingReflectionWithDynamic(string addinPath)
        {
            double x = 3;
            double y = 4;
            dynamic calc = GetCalculator(addinPath);
            double result = calc.Add(x, y);
            Console.WriteLine($"the result of {x} and {y} is {result}");

            try
            {
                result = calc.Multiply(x, y);
            }
            catch (RuntimeBinderException ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void UsingReflection(string addinPath)
        {
            double x = 3;
            double y = 4;
            object calc = GetCalculator(addinPath);

            object result = calc.GetType().GetMethod("Add").Invoke(calc, new object[] { x, y });
            Console.WriteLine($" {x} + {y} = {result}");
        }

        private static object GetCalculator(string addinPath)
        {
            Assembly assembly = Assembly.LoadFile(addinPath);
            return assembly.CreateInstance(CalculatorTypeName);
        }
    }
}
