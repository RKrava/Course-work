﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Course_work
{
    class Storage
    {
        List<Product> Products;
        PurchaseQueue PurchaseQueue;
        List<ComplitedOrder> HistoryOrder;

        public void MakeOrder(Customer customer, List<OrderProduct> orderProducts)
        {
            Order order = new Order(orderProducts, customer, this);

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
        public void ExecuteOrder(Order order)
        {
            bool completed = true;
            List<OrderProduct> purchasequeue = new List<OrderProduct>();
            foreach (OrderProduct item in order.OrderProducts)
            {
                if (CheckInStock(item.Product, item.Quantity))
                {
                    foreach (var product in Products)
                    {
                        if (item.Product.Id == product.Id)
                        {
                            product.RealseOrder(item.Quantity);
                        }
                    }
                }
                else
                {
                    completed = false;
                    int lack = 0;
                    foreach(var good in Products)
                    {
                        if (item.Product.Id == good.Id)
                        {
                            lack = good.Quantity - item.Quantity;
                        }
                    }
                    OrderProduct product = new OrderProduct(item.Product,lack);
                    purchasequeue.Add(product);
                }
            }
            if (completed)
            {
                order.CompleteOrder();
                AddToHistory(order);
            }
            else
            {
                AddToPurchaseQueue(purchasequeue);
            }
        }
        public void AddToHistory(Order order)
        {
            ComplitedOrder complitedOrder = new ComplitedOrder(order.OrderProducts, order.Customer, DateTime.Now, order.Storage);
            HistoryOrder.Add(complitedOrder);
        }
        public void AddToPurchaseQueue(List<OrderProduct> orderProducts)
        {
            Order order = new Order(orderProducts);
            PurchaseQueue.Orders.Enqueue(order);
        }
    }
}