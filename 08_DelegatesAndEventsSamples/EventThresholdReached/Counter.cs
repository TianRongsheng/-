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
            total += x;//total=total+x
            if (total >= threshold)
            {
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                args.Threshold = threshold;
                args.TimeReached = DateTime.Now;//时间等于当前时间
                OnThresholdReached(args);
            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
        //event 关键字用于声明发布服务器类中的事件。此地正在定义事件
        //EventHandler 表示当事件提供数据时将处理该事件的方法。
    }
}
