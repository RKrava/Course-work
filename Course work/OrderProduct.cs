using System;
using System.Collections.Generic;
using System.Text;

namespace Course_work
{
    class OrderProduct
    {
        public OrderProduct(Product product, int quantitytobuy)
        {
            Product = product;
            QuantityToBuy = quantitytobuy;
        }
        public Product Product { get; set; }
        public int QuantityToBuy { get; set; }
    }
}
