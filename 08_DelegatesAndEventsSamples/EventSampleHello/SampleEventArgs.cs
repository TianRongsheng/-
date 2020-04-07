using System;
using System.Collections.Generic;
using System.Text;

namespace EventSampleHello
{
    public class SampleEventArgs
    {
        public SampleEventArgs(string s) { Text = s; }
        public String Text { get; } // readonly
    }
}
