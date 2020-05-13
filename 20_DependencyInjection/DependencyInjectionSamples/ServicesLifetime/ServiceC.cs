using System;

namespace ServicesLifetime
{
    public class ServiceC : IServiceC, IDisposable
    {
        private bool _isDisposed = false;
        private readonly int _n;
        public ServiceC(INumberService numberService)
        {
            _n = numberService.GetNumber();
            Console.WriteLine($"ctor {nameof(ServiceC)}, {_n}");
        }

        public void C()
        {
            //增加了释放资源时调用判断
            if (_isDisposed)
                throw new ObjectDisposedException("ServiceC");

            Console.WriteLine($"{nameof(C)}, {_n}");
        }
        public void Dispose()
        {
            Console.WriteLine($"disposing {nameof(ServiceC)}, {_n}");
            _isDisposed = true;
        }
    }
}
