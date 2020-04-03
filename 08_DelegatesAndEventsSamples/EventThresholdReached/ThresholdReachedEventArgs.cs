using System;
using System.Collections.Generic;
using System.Text;

namespace EventThresholdReached
{
    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
}
