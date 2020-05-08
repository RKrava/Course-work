using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Course_work
{
    //TODO: МОжет таки OrderQueue?
    public class NotComplitedOrders
    {
        public List<Order> Orders { get; set; }

        public NotComplitedOrders()
        {
            Orders = new List<Order>();
        }
        public bool TryExecuteLastOrder()
        {
            Order order = Orders.Last();
            if (order.Storage.ExecuteOrder(order))
            {
                Orders.Remove(order);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void TryExecuteAllOrders()
        {
            foreach (var item in Orders.ToList())
            {
                if (item.Storage.ExecuteOrder(item))
                {
                    Orders.Remove(item);
                }
            }
        }

    }
}
