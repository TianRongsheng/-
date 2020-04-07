using System;
using System.Collections.Generic;
using System.Text;

namespace EventSampleHello
{
  public  class Message:Publisher
    {
       public void onWriteHello()
        {
            RaiseSampleEvent();
        }
    }
}
