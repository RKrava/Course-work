using System;
using System.Collections.Generic;
using System.Text;
using Course_work.Models;

namespace Course_work
{
    public class Order
    {
        static int NumberOfOrders = 0;
        bool completed = false;
        public Order(List<OrderProduct> orderProducts, Customer customer, Storage storage)
        {
            OrderProducts = orderProducts;
            Customer = customer;
            Ordernumber = ++NumberOfOrders;
            Storage = storage;
        }
        public Order(List<OrderProduct> orderProducts)
        {
            OrderProducts = orderProducts;
            Ordernumber = ++NumberOfOrders;
        }
        public void CompleteOrder()
        {
            completed = true;
            NumberOfOrders -= 1;
            Console.WriteLine($"Order #{Ordernumber} Completed!!"); // delegat
        }
        public List<OrderProduct> OrderProducts { get; set; }
        public Storage Storage { get; set; }
        public Customer Customer { get; set; }
        public int Ordernumber { get; set; }
    }
}
