using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Course_work
{
    public class NotCompletedOrders
    {
        public List<Order> Orders { get; set; }

        public NotCompletedOrders()
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
                Orders.Remove(order);
                return false;
            }
        }
        public void TryExecuteAllOrders()
        {
            foreach (var item in Orders.ToList())
            {
                item.Storage.ExecuteOrder(item);
                Orders.Remove(item);
            }
        }

    }
}
