using System;
using System.Collections.Generic;
using System.Text;

namespace EventThresholdReached
{
    //自定义事件参数类---必须继承EventArgs
    //名字有约定，必须EventArgs为后缀
    //用来在事件发生时，向订阅者传递数据
    public class ThresholdReachedEventArgs : EventArgs
    {
        //阈值到达自定义事件--参数1（自定义）---阈值
        public int Threshold { get; set; }
        // //阈值到达自定义事件--参数1（自定义）---时间
        public DateTime TimeReached { get; set; }

    }
}
