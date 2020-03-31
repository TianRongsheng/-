using System;

namespace ActionAndFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Action action = new Action(calculator.Report);
            calculator.Report();
            action.Invoke();
            action();
            Func<int, int, int> func1 = new Func <int, int, int>(calculator.Add);
            Func<int, int, int> func2 = new Func<int, int, int>(calculator.Sub);
            int x = 100;
            int y = 200;
            int z = 0;
            z = func1.Invoke(x, y);
            Console.WriteLine(z);
            z = func2.Invoke(x, y);
            Console.WriteLine(z);

        }
    }
}
