using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace AsyncUWP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string GetThread()
        {
            return $"线程：{Environment.CurrentManagedThreadId}";
        }
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void OnStartAsync(object sender, RoutedEventArgs e)
        {
            text1.Text = $"UI 线程：{GetThread()}";
            await Task.Delay(1000);
            text1.Text += $"\n await 之后：{GetThread()}";
        }

        private async void OnStartAsyncConfigAwait(object sender, RoutedEventArgs e)
        {
           //在UI线程上写入文本
            text1.Text = $"UI 线程: {GetThread()}";
            //异步调用AsyncFunction()且延续上下文
            string s = await AsyncFunction().ConfigureAwait(continueOnCapturedContext: true);

            // await之后,可在UI线程写入文本
            text1.Text += $"\n{s}\nawait 之后: {GetThread()}";

           //局部方法
            async Task<string> AsyncFunction()
            {
                string result = $"\n内部的异步方法线程: {GetThread()}\n";
                //异步调用任务，且不延续上下文
                await Task.Delay(1000).ConfigureAwait(continueOnCapturedContext: false);
                result += $"\na内部的异步方法线程await之后 : {GetThread()}";
                try
                {
                    //由于当前线程不在UI上，因此无法写入文本
                    text1.Text = "这是一个来自错误线程的调用";
                    return "到不了这里";
                }
                catch (Exception ex) when (ex.HResult == -2147417842)
                {
                    return result;
                    // we know it's the wrong thread, so don't access
                    // UI elements from the previous try block
                }
            }
        }

        private async void OnStartAsyncThreadSwitch(object sender, RoutedEventArgs e)
        {
            text1.Text = $"UI 线程: {GetThread()}";

            string s = await AsyncFunction();

            text1.Text += $"\n{s}\nawait之后: {GetThread()}";

            //内部方法
            async Task<string> AsyncFunction()
            {
                string result = $"\n内部的异步方法: {GetThread()}\n";
                //配置继续捕捉上下文为假
                await Task.Delay(1000).ConfigureAwait(continueOnCapturedContext: false);
                //切换了非UI线程
                result += $"\n内部的异步方法在等待延迟之后 : {GetThread()}";


                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    //使用Dispatcher将当前任务切换到UI线程上
                    //CoreDispatcherPriority.Normal定义事件调度优先级
                    //当前操作仍然可以写入UI
                    text1.Text += $"\n异步方法切换回UI线程: {GetThread()}";
                });

                return result;
            }
        }

        private async void OnIAsyncOperation(object sender, RoutedEventArgs e)
        {
            var dlg = new MessageDialog("单击1-3号", "简单例子");

            dlg.Commands.Add(new UICommand("1号", null, 1));
            dlg.Commands.Add(new UICommand("2号", null, 2));
            dlg.Commands.Add(new UICommand("3号", null, 3));

            IUICommand command = await dlg.ShowAsync();

            text1.Text = $"点击了{command.Id}号ID对应的{command.Label} 标签";
        }

        private void OnStartDeadlock(object sender, RoutedEventArgs e)
        {
           DelayAsync().Wait();
            text1.Text +="\n死锁了";
        }
        private async Task DelayAsync() 
        {
            await Task.Delay(1000);
        }
    }
}
