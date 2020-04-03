using System;

namespace ActionAndFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            //定义Action委托变量，封装calculator.Report
            Action action = new Action(calculator.Report);
            
            //调用等价式样三联
            calculator.Report();
            action.Invoke();
            action();
            //Func<参数1类型,参数2类型,返回值类型> func1 = new Func<参数1类型,参数2类型,返回值类型>(封装方法);
            Func<int, int, double> func1 = new Func <int, int, double>(calculator.Add);
            Func<int, int, double > func2 = new Func<int, int, double>(calculator.Sub);
            int x = 100;
            int y = 200;
            double z1,z2,z3= 0;
            z1 = calculator.Add(x, y);
            z2 = func1.Invoke(x, y);
            z3 = func1(x, y);
            Console.WriteLine($"z1={z1}  z2={z2} z3={z3}");
            z1 = func2.Invoke(x, y);
            Console.WriteLine(z1);

        }
    }
}
