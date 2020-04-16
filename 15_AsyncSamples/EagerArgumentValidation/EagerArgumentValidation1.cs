using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace EagerArgumentValidation
{
    [Description(" (separate method for implementation)")]
    public class EagerArgumentValidation1
    {
        // This method is the same as in LazyArgumentValidation;
        // only ComputeLengthAsync is different.
        public static async Task MainAsync()
        {
            Task<int> task = ComputeLengthAsync(null);
            Console.WriteLine("Fetched the task");
            int length = await task;
            Console.WriteLine("Length: {0}", length);
        }

        public static Task<int> ComputeLengthAsync(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            return ComputeLengthAsyncImpl(text);
        }

        public static async Task<int> ComputeLengthAsyncImpl(string text)
        {
            await Task.Delay(500);
            return text.Length;
        }
    }
}

