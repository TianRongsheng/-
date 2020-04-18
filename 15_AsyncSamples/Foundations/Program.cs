using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Foundations
{
    class Program
    {

        private static readonly Command[] commands =
        {
           
            new Command("-async", nameof(CallerWithAsync), CallerWithAsync),
            new Command("-async2", nameof(CallerWithAsync2), CallerWithAsync2),
            new Command("-awaiter", nameof(CallerWithAwaiter), CallerWithAwaiter),
            new Command("-cont", nameof(CallerWithContinuationTask), CallerWithContinuationTask),
            new Command("-masync", nameof(MultipleAsyncMethods), MultipleAsyncMethods),
            new Command("-comb", nameof(MultipleAsyncMethodsWithCombinators1), MultipleAsyncMethodsWithCombinators1),
            new Command("-comb2", nameof(MultipleAsyncMethodsWithCombinators2), MultipleAsyncMethodsWithCombinators2),
            new Command("-val", nameof(UseValueTask), UseValueTask),
            new Command("-casync", nameof(ConvertingAsyncPattern), ConvertingAsyncPattern)
        };

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                ShowUsage();
                return;
            }

            Command command = commands.SingleOrDefault(c => c.Option == args[0]);
            if (command == null)
            {
                ShowUsage();
                return;
            }
            command.Action();

            Console.ReadLine();
        }


        private static void ShowUsage()
        {
            Console.WriteLine("Usage: Foundations [options]");
            Console.WriteLine();
            foreach (var command in commands)
            {
                Console.WriteLine($"{command.Option} {command.Text}");
            }
        }

        private static async void UseValueTask()
        {
            TraceThreadAndTask($"start {nameof(UseValueTask)}");
            string result = await GreetingValueTask2Async("Katharina");
            Console.WriteLine(result);
            TraceThreadAndTask($"first result {nameof(UseValueTask)}");
            string result2 = await GreetingValueTask2Async("Katharina");
            Console.WriteLine(result2);
            TraceThreadAndTask($"ended {nameof(UseValueTask)}");
        }

        private static async void ConvertingAsyncPattern()
        {
            HttpWebRequest request = WebRequest.Create("http://www.microsoft.com") as HttpWebRequest;

            using (WebResponse response = await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse(null, null), request.EndGetResponse))
            {
                Stream stream = response.GetResponseStream();
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine(content.Substring(0, 100));
                }
            }
        }

        private static  async void MultipleAsyncMethods()
        {
           string s1 = await GreetingAsync("Stephanie");
           string s2 = await GreetingAsync("Matthias");
 
            Console.WriteLine($"Finished both methods.{Environment.NewLine} Result 1: {s1}{Environment.NewLine} Result 2: {s2}");
        }

        private static async void MultipleAsyncMethodsWithCombinators1()
        {
            Task<string> t1 = GreetingAsync("Stephanie");
            Task<string> t2 = GreetingAsync("Matthias");
            await Task.WhenAll(t1, t2);
            Console.WriteLine($"Finished both methods.{Environment.NewLine} Result 1: {t1.Result}{Environment.NewLine} Result 2: {t2.Result}");
        }

        private static async void MultipleAsyncMethodsWithCombinators2()
        {
            Task<string> t1 = GreetingAsync("Stephanie");
            Task<string> t2 = GreetingAsync("Matthias");
            string[] result = await Task.WhenAll(t1, t2);
            Console.WriteLine($"Finished both methods.{Environment.NewLine} Result 1: {result[0]}{Environment.NewLine} Result 2: {result[1]}");
        }

        private static void CallerWithContinuationTask()
        {
            TraceThreadAndTask($"started {nameof(CallerWithContinuationTask)}");

            var t1 = GreetingAsync("Stephanie");

            t1.ContinueWith(t =>
            {
                string result = t.Result;
                Console.WriteLine(result);

                TraceThreadAndTask($"ended {nameof(CallerWithContinuationTask)}");
            });
        }

        private static void CallerWithAwaiter()
        {
            TraceThreadAndTask($"starting {nameof(CallerWithAwaiter)}");
            TaskAwaiter<string> awaiter = GreetingAsync("Matthias").GetAwaiter();
            awaiter.OnCompleted(OnCompleteAwaiter);

            void OnCompleteAwaiter()
            {
                Console.WriteLine(awaiter.GetResult());
                TraceThreadAndTask($"ended {nameof(CallerWithAwaiter)}");
            }
        }
        /// <summary>
        /// 异步方法
        /// 内含await
        /// 用async修饰
        /// </summary>
        private static async void CallerWithAsync()
        {
            //跟踪线程任务
            TraceThreadAndTask($"started {nameof(CallerWithAsync)}");
            //调用异步方法，异步获取祝词
            string result = await GreetingAsync("Stephanie");
            //当异步获取祝词方法执行完毕前，余下行会被阻塞
            //但启用本方法CallerWithAsync的线程可以被重用
            Console.WriteLine(result);
            TraceThreadAndTask($"ended {nameof(CallerWithAsync)}");
        }

        private static async void CallerWithAsync2()
        {
            TraceThreadAndTask($"started {nameof(CallerWithAsync2)}");
            Console.WriteLine(await GreetingAsync("Stephanie"));
            TraceThreadAndTask($"ended {nameof(CallerWithAsync2)}");
        }

        /// <summary>
        /// 创建祝词字符串异步获取任务
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static Task<string> GreetingAsync(string name)
        {
            Task<string> t;
            //将指定的工作放在线程池中运行，并返回一个任务
            t = Task.Run(() =>
              {
                  TraceThreadAndTask($"running {nameof(GreetingAsync)}");
                  return Greeting(name);
              });
            return t;
        }
        private readonly static Dictionary<string, string> names = new Dictionary<string, string>();

        static async ValueTask<string> GreetingValueTaskAsync(string name)
        {
            if (names.TryGetValue(name, out string result))
            {
                return result;
            }
            else
            {
                result = await GreetingAsync(name);
                names.Add(name, result);
                return result;
            }
        }

        static ValueTask<string> GreetingValueTask2Async(string name)
        {
            if (names.TryGetValue(name, out string result))
            {
                return new ValueTask<string>(result);
            }
            else
            {
                Task<string> t1 = GreetingAsync(name);

                TaskAwaiter<string> awaiter = t1.GetAwaiter();
                awaiter.OnCompleted(OnCompletion);
                return new ValueTask<string>(t1);

                void OnCompletion()
                {
                    names.Add(name, awaiter.GetResult());
                }
            }
        }
        /// <summary>
        /// 延迟一段事件后返祝词回字符串--人为设置阻塞
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static string Greeting(string name)
        {
            //显示当前线程和任务ID
            TraceThreadAndTask($"running {nameof(Greeting)}");
            //延迟3000毫秒，等待任务执行完成
            Task.Delay(3000).Wait();
            //返回问候语字符串
            return $"Hello, {name}";
        }
        /// <summary>
        /// 跟踪线程和任务
        /// </summary>
        /// <param name="info"></param>
        public static void TraceThreadAndTask(string info)
        {
            //获取当前任务的ID号
            string taskInfo = Task.CurrentId == null ? "no task" : "task " + Task.CurrentId;
            //输出当前活动的线程号和任务ID号
            Console.WriteLine($"{info} in thread {Thread.CurrentThread.ManagedThreadId} and {taskInfo}");
        }
    }
}