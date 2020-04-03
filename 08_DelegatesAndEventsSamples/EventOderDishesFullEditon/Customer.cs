using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EventOderDishesFullEditon
{
    public class Customer
    {
        private OrderEventHandler orderEventHandler;
        public event OrderEventHandler Order
        {
            add
            {
                this.orderEventHandler += value;
            }
            remove
            {
                this.orderEventHandler -= value;
            }
        }

        public void WalkIn()
        {
            Console.WriteLine("进店.");
        }
        public void SitDown()
        {
            Console.WriteLine("坐下来.");
        }
        public void Think()
        {
            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine("吃什么呢 ...");
                Thread.Sleep(1000);
            }

            string dishes= "螺蛳粉";
            string size = "大";
            Console.WriteLine($"来碗{size}份{dishes}");
            Thread.Sleep(1000);

            if (this.orderEventHandler != null)
                {
                    OrderEventArgs e = new OrderEventArgs();
                    e.DishName = dishes;
                    e.Size = size;
                    this.orderEventHandler.Invoke(this, e);
                }           
        }


        public void Action()
        {
            this.WalkIn();
            Thread.Sleep(1000);
            this.SitDown();
            Thread.Sleep(1000);
            this.Think();
        }

        public double Bill { get; set; }
        public void PayTheBill()
        {
            Console.WriteLine($"我需要支付---￥{this.Bill}.");
        }

    }
}
