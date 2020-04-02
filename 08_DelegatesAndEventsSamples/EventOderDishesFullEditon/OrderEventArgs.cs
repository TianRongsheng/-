using System;
using System.Collections.Generic;
using System.Text;

namespace EventOderDishesFullEditon
{
    public class OrderEventArgs : EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }

}
