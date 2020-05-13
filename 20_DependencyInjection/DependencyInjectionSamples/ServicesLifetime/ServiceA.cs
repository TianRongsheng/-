using System;

namespace ServicesLifetime
{
    public class ServiceA : IServiceA, IDisposable
    {
        private readonly int _n;
        //通过构造函数注入INumberService
        public ServiceA(INumberService numberService)
        {
            //获取数码，并赋值给私有变量_n
            _n = numberService.GetNumber();
           //在对象构建时输出_n--观察对象生命周期
            Console.WriteLine($"ctor {nameof(ServiceA)}, {_n}");
        }

        public void A()
        {
            //在对象运行时输出_n--观察对象生命周期
            Console.WriteLine($"{nameof(A)}, {_n}");
        }

        public void Dispose()
        {
            //在对象销毁时输出_n--观察对象生命周期
            Console.WriteLine($"disposing {nameof(ServiceA)}, {_n}");
        }
        
    }
}
