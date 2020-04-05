using System;
using System.Collections.Generic;
using System.Text;

namespace Course_work
{
    class Order
    {
        static int NumberOfOrders = 0;
        int Ordernumber;
        bool completed;
        public Order(List<OrderProduct> orderProducts, Customer customer, Storage storage)
        {
            OrderProducts = orderProducts;
            Customer = customer;
            Ordernumber = ++NumberOfOrders;
            Storage = storage;
            completed = false;
        }
        public Order(List<OrderProduct> orderProducts)
        {
            OrderProducts = orderProducts;
            Ordernumber = ++NumberOfOrders;
            completed = false;
        }
        public void CompleteOrder()
        {
            completed = true;
        }
        public List<OrderProduct> OrderProducts { get; set; }
        public Storage Storage { get; set; }
        public Customer Customer { get; set; }
    }
}
