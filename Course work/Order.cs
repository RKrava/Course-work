using System;
using System.Collections.Generic;
using System.Text;

namespace Course_work
{
    class Order
    {
        static int NumberOfOrders;
        int Ordernumber;
        List<OrderProduct> OrderProducts;
        Customer Customer;
        bool completed;
        public Order(List<OrderProduct> orderProducts, Customer customer, Storage storage)
        {
            OrderProducts = orderProducts;
            Customer = customer;
            Ordernumber = ++NumberOfOrders;
            completed = false;
            ExecuteOrder(storage, customer);
        }
        public void ExecuteOrder(Storage storage, Customer customer)
        {
            foreach(OrderProduct item in OrderProducts)
            {
                if(storage.CheckInStock(item.GetProduct, item.GetQuantity))
                {
                    storage.ExecuteOrder(OrderProducts, this, storage, customer);
                }
                else
                {

                }
            }
        }
        public void CompleteOrder()
        {
            completed = true;
        }
    }
}
