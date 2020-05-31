using System;
using System.Collections.Generic;

namespace Course_work.Models
{
    public class CompletedOrder : Order // клас який буде охарактиризовувати завершенні замовлення
    {
        #region Properties
        public DateTime Leadtime { get; } // час заверщення замовлення
        #endregion
        public CompletedOrder(List<OrderProduct> orderProducts, Customer customer, DateTime leadtime, Storage storage) : base(orderProducts, customer, storage)
        {
            Leadtime = leadtime;
        }

    }
}
