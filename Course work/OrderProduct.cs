using System;
using System.Collections.Generic;
using System.Text;

namespace Course_work
{
    class OrderProduct
    {
        public OrderProduct(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
