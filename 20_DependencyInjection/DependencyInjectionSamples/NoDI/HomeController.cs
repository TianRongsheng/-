namespace NoDI
{
    public class HomeController
    {
        public string Hello(string name)
        {
            var service = new GreetingService();
            return service.Greet(name);
            
        }
        public string HelloTest(string name)
        {
            var serviceTest = new SerivceGreetCn();
            return serviceTest.Serivce(name);
        }
    }
}
