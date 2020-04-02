using System;
using System.Collections.Generic;
using System.Text;

namespace EventOderDishesFullEditon
{
    public class Waiter
    {
        public void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine($"我是服务员-给您上 - {e.DishName}.");
            double price = 10;
            switch (e.Size)
            {
                case "小": price *= 0.5; break;
                case "大": price *= 1.5; break;
                default: break;
            }
            customer.Bill += price;
        }
    }
}
