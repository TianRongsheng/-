using System;

namespace EagerArgumentValidation
{
    class Program
    {
        static void Main(string[] args)
        {

            EagerArgumentValidation1.MainAsync().GetAwaiter().GetResult();
            EagerArgumentValidation2.MainAsync().GetAwaiter().GetResult();
            EagerArgumentValidation3.MainAsync().GetAwaiter().GetResult();
        }
    }
}
