using System.Threading;

namespace ServicesLifetime
{
    public class NumberService : INumberService
    {
        private int _number = 0;
        public int GetNumber()
        {
            //Interlocked为多个线程共享的变量提供原子操作。
            //Interlocked.Increment以原子操作的形式递增指定变量的值并存储结果。
            //每调用一次返回一个新号码
            return Interlocked.Increment(ref _number);
        }
    }
}
