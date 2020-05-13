using System;

namespace WithDI
{
    public class HomeController
    {
        private readonly IGreetingService _greetingService;
        private readonly ISerivceGreetCn _serivceGreetCn;
        public HomeController(IGreetingService greetingService)
        {
            _greetingService = greetingService ?? throw new ArgumentNullException(nameof(greetingService));
        }
        public string Hello(string name)
        {
            return _greetingService.Greet(name);
        }
        public HomeController(ISerivceGreetCn serivceGreetCn)
        {
            _serivceGreetCn = serivceGreetCn ?? throw new ArgumentNullException(nameof(serivceGreetCn));
        }
        public string HelloTest(string name)
        {
            return _serivceGreetCn.Serivce(name);
        }
    }
}
