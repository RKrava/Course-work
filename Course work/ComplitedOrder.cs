using System;
using System.Collections.Generic;
using System.Text;

namespace Course_work
{
    class ComplitedOrder : Order
    {
        DateTime Leadtime;
        public ComplitedOrder(List<OrderProduct> orderProducts, Customer customer, DateTime leadtime, Storage storage) : base(orderProducts, customer, storage)
        {
            Leadtime = leadtime;
        }

    }
}
