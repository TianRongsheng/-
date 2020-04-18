using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace EagerArgumentValidation
{
    [Description("(anonyous async function)")]
 public   class EagerArgumentValidation2
    {
  
        // This method is the same as in LazyArgumentValidation;
        // only ComputeLengthAsync is different.
  public      static async Task MainAsync()
        {
            Task<int> task = ComputeLengthAsync(null);
            Console.WriteLine("Fetched the task");
            int length = await task;
            Console.WriteLine("Length: {0}", length);
        }

        static Task<int> ComputeLengthAsync(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            // This could just be a Func<Task<int>> using
            // text, but that would be less efficient than passing
            // the value in directly.
            Func<string, Task<int>> impl = async t =>
            {
                await Task.Delay(500);
                return text.Length;
            };
            return impl(text);
        }
    }
}