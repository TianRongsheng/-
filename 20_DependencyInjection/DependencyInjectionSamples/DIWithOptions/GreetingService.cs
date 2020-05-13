using Microsoft.Extensions.Options;

namespace DIWithOptions
{
    public class GreetingService : IGreetingService
    {
       //新增一个选项参数，从构造函数中注入
        public GreetingService(IOptions<GreetingServiceOptions> options)
        {
            _from = options.Value.From;
        }
        
        private readonly string _from;

        public string Greet(string name) 
        {
           return  $"你好, {name}! --来自{_from}的问候";
        }
    }
}
