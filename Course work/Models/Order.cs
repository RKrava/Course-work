using System;
using System.Collections.Generic;
using System.Text;
using Course_work.Models;

namespace Course_work
{
    public class Order
    {
        //TODO: private
        static int NumberOfOrders = 0;
        //TODO: нейминг
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
            //TODO: это не будет работать, у них номера поедут и будут дублироваться
            NumberOfOrders -= 1;
            Console.WriteLine($"Order #{Ordernumber} Completed!!");
        }
        public List<OrderProduct> OrderProducts { get; set; }

        //TODO: Тебе не нужно это свойство. Попробуй его убрать
        public Storage Storage { get; set; }
        public Customer Customer { get; set; }
        public int Ordernumber { get; set; }
    }
}
