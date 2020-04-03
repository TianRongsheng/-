using System;
using System.Collections.Generic;
using System.Text;

namespace EventThresholdReached
{
    class Counter
    {
        private int threshold;
        private int total;

        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }

        public void Add(int x)
        {
            total += x;
            
            if (total >= threshold)
            {
                //阈值到达
                //1.事件数据参数实例化args
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                //2.事件参数实例args的属性赋值
                args.Threshold = threshold;
                args.TimeReached = DateTime.Now;
                //3.调用触发事件方法，方法名字自定义。约定以On开头。还有时态约束
                
                // OnThresholdReached(args);

                //创建一个委托变量handler，受EventHandler<ThresholdReachedEventArgs>约束
                //handler获得事件ThresholdReached，handler可以在事件发生时调用事件订阅者方法
                EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
               //事件订阅者如果不为空
                if (handler != null)
                {
                    //间接调用事件订阅者的事件处理器方法。
                    handler(this, args);
                }
            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            ThresholdReached?.Invoke(this, e);
        }

        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;

    }
}
