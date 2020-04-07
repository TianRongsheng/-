using System;
using System.Collections.Generic;
using System.Text;

namespace EventSampleHello
{
    public class Publisher
    {
        // 自定义委托类型SampleEventHandler
        public delegate void SampleEventHandler(object sender, SampleEventArgs e);

        // 定义基于SampleEventHandler委托类型的事件SampleEvent
        public event SampleEventHandler SampleEvent;

        // 将事件置入受保护的虚方法中，可以让派生类触发事件
        protected virtual void RaiseSampleEvent()
        {
            // 触发事件
            SampleEvent?.Invoke(this, new SampleEventArgs("Hello"));
        }
    }
}
