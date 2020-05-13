using System;

namespace NoDI
{
    class Program
    {
        static void Main()
        {
            var controller = new HomeController();
            string result = controller.Hello("Stephanie");
            Console.WriteLine(result);

            var test = new HomeController();
            string resultTest = test.HelloTest("潇洒");
            Console.WriteLine(resultTest);
        }
    }
}
