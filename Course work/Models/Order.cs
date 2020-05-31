using System.Collections.Generic;
using Course_work.Models;

namespace Course_work
{
    public class Order : IOrder
    {
        public delegate void OrderComplete(string message); // об'являємо тип делегата 
        public static event OrderComplete Notify; // подія яка буде викликатись при завершення замовлення
        static int NumberOfOrders = 0; 
        public Order(List<OrderProduct> orderProducts, Customer customer, Storage storage)
        {
            OrderProducts = orderProducts;
            Customer = customer;
            Ordernumber = ++NumberOfOrders;
            Storage = storage;
        }
        public void CompleteOrder() // метод заверщення замовлення
        {
            NumberOfOrders -= 1;
            Notify?.Invoke($"Order #{Ordernumber} Completed!!");
        }
        #region Properties
        public List<OrderProduct> OrderProducts { get; set; }
        public Storage Storage { get; set; }
        public Customer Customer { get; set; }
        public int Ordernumber { get; set; }
        #endregion
    }
}
