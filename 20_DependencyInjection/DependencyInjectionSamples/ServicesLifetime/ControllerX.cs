using System;

namespace ServicesLifetime
{
    public class ControllerX : IDisposable
    {
        private readonly IServiceA _serviceA;
        private readonly IServiceB _serviceB;
        private readonly int _n;
        private int _countm = 0;

        //要求构造函数注入三个服务 服务A/B和数字服务
        public ControllerX(IServiceA serviceA, IServiceB serviceB, INumberService numberService)
        {
            _n = numberService.GetNumber();
            Console.WriteLine($"ctor {nameof(ControllerX)}, {_n}");
            _serviceA = serviceA;
            _serviceB = serviceB;
        }

        public void M()
        {
            //记录M被调用次数
            Console.WriteLine($"invoked {nameof(M)} for the {++_countm}. time");
            //调用服务A
            _serviceA.A();
            //调用服务B
            _serviceB.B();
        }

        public void Dispose()
        {
            //在控制台中记录_n
            Console.WriteLine($"disposing {nameof(ControllerX)}, {_n}");
        }
      
    }
}
