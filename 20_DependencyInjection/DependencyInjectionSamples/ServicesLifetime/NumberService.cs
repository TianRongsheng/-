using System.Threading;

namespace ServicesLifetime
{
    public class NumberService : INumberService
    {
        private int _number = 0;
        public int GetNumber()
        {
            return Interlocked.Increment(ref _number);
        }
    }
}
