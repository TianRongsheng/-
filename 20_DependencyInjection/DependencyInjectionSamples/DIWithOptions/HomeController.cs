namespace DIWithOptions
{
    public class HomeController
    {
        private readonly IGreetingService _greetingService;
        public HomeController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }
        public string Hello(string name) {
           return  _greetingService.Greet(name);
        }
    }
}
