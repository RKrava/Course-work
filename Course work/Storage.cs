using System;
using System.Collections.Generic;
using Course_work.Models;

namespace Course_work
{
    public class Storage
    {
        public string Name;

        public List<Pair<Product,int>> Products = new List<Pair<Product,int>>();
        public NotCompletedOrders NotCompletedOrders = new NotCompletedOrders();
        public List<CompletedOrder> HistoryOrder = new List<CompletedOrder>();

        public Storage(List<Pair<Product,int>> products, string name)
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
                        orderProducts.RemoveAt(j);
                        i = 0;
                        j = 0;
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
                if (item.First.Id == product.Id && item.Second >= quantity)
                {
                    return true;
                }
            }
            return false;
        }
        public bool ExecuteOrder(Order order)
        {
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
                        if (item.Product.Id == product.First.Id)
                        {
                            SendProduct(product,item.QuantityToOrder);
                        }
                    }
                }
                order.CompleteOrder();
                AddToHistory(order);
            }
            else
            {
                NotCompletedOrders.Orders.Add(order);
            }
            return executable;
        }
        public void AddToHistory(Order order)
        {
            CompletedOrder complitedOrder = new CompletedOrder(order.OrderProducts, order.Customer, DateTime.Now, order.Storage);
            HistoryOrder.Add(complitedOrder);
        }
        public void AddProduct(Product product, int quantity)
        {
            bool available = false;
            if (Products != null)
            {
                foreach (var item in Products)
                {
                    if (product.Id == item.First.Id)
                    {
                        item.Second+=quantity;
                        available = true;
                    }
                }
            }
            if (!available)
            {
                var pair = new Pair<Product, int>();
                pair.First = new Product(product);
                pair.Second = quantity;
                Products.Add(pair);
            }
            
            NotCompletedOrders.TryExecuteAllOrders();
        }
        public void SendProduct(Pair<Product,int> pair, int quantity)
        {
            pair.Second -= quantity;
        }
    }
}
