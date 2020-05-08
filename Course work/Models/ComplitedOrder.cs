using System;
using System.Collections.Generic;

namespace Course_work.Models
{
    public class ComplitedOrder : Order
    {
        public DateTime Leadtime { get; }

        public ComplitedOrder(List<OrderProduct> orderProducts, Customer customer, DateTime leadtime, Storage storage) : base(orderProducts, customer, storage)
        {
            Leadtime = leadtime;
        }

    }
}
