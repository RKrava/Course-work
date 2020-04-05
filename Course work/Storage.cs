using System;
using System.Collections.Generic;
using System.Text;

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
            foreach(var item in Products)
            {
                if (item.GetId == product.GetId && item.GetQuantity >= quantity)
                {
                    return true;
                }
            }
            return false;
        }
        public void ExecuteOrder(List<OrderProduct> orderproducts, Order order, Storage storage, Customer customer)
        {
            foreach(var item in orderproducts)
            {
                foreach(var product in Products)
                {
                    if(item.GetProduct.GetId == product.GetId)
                    {
                        product.RealseOrder(item.GetQuantity);
                        order.CompleteOrder();
                        storage.AddToHistory(storage, order, orderproducts, customer);
                    }
                }
            }
        }
        public void AddToHistory(Storage storage, Order order, List<OrderProduct> orderProducts, Customer customer)
        {
            ComplitedOrder complitedOrder = new ComplitedOrder(orderProducts, customer, DateTime.Now, storage);
            HistoryOrder.Add(complitedOrder);
        }
    }
}
