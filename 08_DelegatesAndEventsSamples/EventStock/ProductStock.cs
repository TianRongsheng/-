using System;
using System.Collections.Generic;
using System.Text;

namespace EventStock
{
    public class ProductStock
    {
        public ProductStock(String name, int inventory)
        {
            Name = name;
            _inventory = inventory;
            UnderStock += UnderStockHandler;
            DealsAreDone += DealsAreDoneHandler;
        }
        public String Name { get; set; }
        int _inventory;
        public int GetInventory() => _inventory;

        public void Reduce(int amount, string consumer)
        {

            if (_inventory - amount < 0)
            {
                var msgArg = new MessageEventArgs(consumer, amount);
                OnUnderStock(msgArg);
            }
            else
            {
                _inventory -= amount;
                var msgArg = new MessageEventArgs(consumer, amount);
                OnDealsAreDone(msgArg);
            }
        }
        protected virtual void OnUnderStock(MessageEventArgs msgArg)
        {
            UnderStock?.Invoke(this, msgArg);
        }
        protected virtual void OnDealsAreDone(MessageEventArgs msgArg)
        {
            DealsAreDone?.Invoke(this, msgArg);
        }

        public event EventHandler<MessageEventArgs> UnderStock;
        public event EventHandler<MessageEventArgs> DealsAreDone;
      
        void UnderStockHandler(object sender, MessageEventArgs e)
        {
            ProductStock ps = (ProductStock)sender;
            Console.WriteLine($"{e.Consumer}欲购买{e.Amount}份{ps.Name}，库存不足！{ps.Name},{DateTime.Now}库存{ps.GetInventory()}");

        }
        void DealsAreDoneHandler(object sender, MessageEventArgs e)
        {
            ProductStock ps = (ProductStock)sender;
            Console.WriteLine($"{e.Consumer}购买{e.Amount}份{ps.Name}，交易成功！{ps.Name},{DateTime.Now}库存{ps.GetInventory()}");
        }


    }
}
