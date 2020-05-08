using System;
using System.Collections.Generic;
using Course_work.Models;

namespace Course_work
{
    public class Storage
    {
        public string Name;

        public List<Product> Products = new List<Product>();
        NotComplitedOrders NotComplitedOrders = new NotComplitedOrders();
        List<ComplitedOrder> HistoryOrder = new List<ComplitedOrder>();

        public Storage(List<Product> products, string name)
        {
            Products = products;
            Name = name;
        }
        public Storage(string name)
        {
            Name = name;
        }
        public Order MakeOrder(Customer customer, List<OrderProduct> orderProducts)
        {
            for(int i = 0; i < orderProducts.Count; i++)
            {
                for(int j = 0; j < orderProducts.Count; j++)
                {
                    if (orderProducts[i].Product.Id == orderProducts[j].Product.Id && i != j) 
                    { 
                        orderProducts[i].QuantityToOrder += orderProducts[j].QuantityToOrder; 
                    }
                }
            }
            Order order = new Order(orderProducts, customer, this);
            return order;
        }
        public bool CheckInStock(Product product, int quantity)
        {
            foreach (var item in Products)
            {
                if (item.Id == product.Id && item.Quantity >= quantity)
                {
                    return true;
                }
            }
            return false;
        }
        public bool ExecuteOrder(Order order)
        {
            List<OrderProduct> purchasequeue = new List<OrderProduct>();
            bool executable = true;
            foreach (OrderProduct item in order.OrderProducts)
            {
                if (!CheckInStock(item.Product, item.QuantityToOrder)) { executable = false; break; }
                }
            if (executable)
            {
                foreach (OrderProduct item in order.OrderProducts)
                {
                    foreach (var product in Products)
                    {
                        if (item.Product.Id == product.Id)
                        {
                            product.RealseOrder(item.QuantityToOrder);
                        }
                    }
                }
                order.CompleteOrder();
                AddToHistory(order);
            }
            else
            {
                NotComplitedOrders.Orders.Add(order);
            }
            return executable;
        }
        public void AddToHistory(Order order)
        {
            ComplitedOrder complitedOrder = new ComplitedOrder(order.OrderProducts, order.Customer, DateTime.Now, order.Storage);
            HistoryOrder.Add(complitedOrder);
        }
        public void AddProduct(Product product)
        {
            bool available = false;
            if (Products != null)
            {
                foreach (var item in Products)
                {
                    if (product.Id == item.Id)
                    {
                        item.AddQuantity(product.Quantity);
                        available = true;
                    }
                }
            }
            if (!available)
            {
                Products.Add(new Product(product, product.Quantity));
            }
            NotComplitedOrders.TryExecuteAllOrders();
        }
    }
}
