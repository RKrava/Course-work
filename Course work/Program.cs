using System;
using System.Collections.Generic;

namespace Course_work
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>();
            var product1 = new Product(123, 11, "ball");
            products.Add(product1);
            var customer = new Customer("Roman");
            var storage = new Storage(products);
            List<OrderProduct> list = new List<OrderProduct>();
            OrderProduct orderProduct = new OrderProduct(product1, 22);
            list.Add(orderProduct);
            Order order = storage.MakeOrder(customer,list);
            storage.ExecuteOrder(order);
            Console.WriteLine();
        }
    }
}
