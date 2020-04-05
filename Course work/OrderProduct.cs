using System;
using System.Collections.Generic;
using System.Text;

namespace Course_work
{
    class OrderProduct
    {
        Product Product;
        int Quantity;
        public OrderProduct(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public Product GetProduct
        {
            get
            {
                return Product;
            }
        }
        public int GetQuantity
        {
            get
            {
                return Quantity;
            }
        }
    }
}
