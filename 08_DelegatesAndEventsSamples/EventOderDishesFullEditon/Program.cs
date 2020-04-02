using System;

namespace EventOderDishesFullEditon
{
    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);

    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order+=waiter.Action;
            customer.Action();
            customer.PayTheBill();




        }
    }
}
