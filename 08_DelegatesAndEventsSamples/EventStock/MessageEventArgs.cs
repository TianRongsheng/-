using System;

namespace EventStock
{
    public class MessageEventArgs:EventArgs
    {
        public MessageEventArgs(string consumer, int amount)
        {                      
            Consumer = consumer;
            Amount = amount;
        } 
        public int Amount { get; }      
        public String Consumer { get; }

    }
}