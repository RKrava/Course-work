using System;
using System.Collections.Generic;
using System.Text;

namespace Course_work
{
    class PurchaseQueue
    {
        public Queue<Order> Orders { get; set; }

        public PurchaseQueue()
        {
            Orders = new Queue<Order>();
        }
        private bool TryExecute()
        {
            //add logic
            return false;
        }
    }
}
