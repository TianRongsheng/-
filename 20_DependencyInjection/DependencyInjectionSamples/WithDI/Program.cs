using System;

namespace WithDI
{
    class Program
    {
        static void Main()
        {
            var controller = new HomeController(new GreetingService());
            string result = controller.Hello("Matthias");
            Console.WriteLine(result);

            var test = new HomeController(new SerivceGreetCn());
            string resultTest = test.HelloTest("潇洒");
            Console.WriteLine(resultTest);
        }
    }
}
