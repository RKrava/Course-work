using System.Collections.Generic;
using System.Linq;

namespace Course_work
{
    public class NotCompletedOrders // клас замовлень які ще не завершились
    {
        #region Properties
        public List<Order> Orders { get; set; } // список не завершенних замовлень
        #endregion
        public NotCompletedOrders()
        {
            Orders = new List<Order>();
        }
        public bool TryExecuteLastOrder() // метод для запуска одного замовлення 
        {
            Order order = Orders.Last();
            if (order.Storage.ExecuteOrder(order))
            {
                Orders.Remove(order);
                return true;
            }
            else
            {
                Orders.Remove(order);
                return false;
            }
        }
        public void TryExecuteAllOrders() // метод для запуска всіх не завершених замовлень 
        {
            foreach (var item in Orders.ToList())
            {
                item.Storage.ExecuteOrder(item);
                Orders.Remove(item);
            }
        }

    }
}
