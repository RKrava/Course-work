using System;
using System.Collections.Generic;
using System.Text;

namespace Course_work.Models
{
    public interface IOrder // інтерфейс для полегшеня внесення змін в клас Order
    {
        public abstract void CompleteOrder();
        #region Properties
        public List<OrderProduct> OrderProducts { get; set; } // список продуктів і кількостей для замовлення
        public Storage Storage { get; set; } // на який склад поступало замовлення
        public Customer Customer { get; set; } // замовник 
        public int Ordernumber { get; set; } // номер замовлення
        #endregion
    }
}
