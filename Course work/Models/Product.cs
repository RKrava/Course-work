using System;
using System.Collections.Generic;
using System.Text;

namespace Course_work
{
    public class Product
    {
        public string Title;
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product(int id, int quantity, string title)
        {
            Id = id;
            Quantity = quantity;
            Title = title;
        }
        public Product(Product product, int quantity)
        {
            Id = product.Id;
            Quantity = quantity;
            Title = product.Title;
        }
        public Product(int id)
        {
            Id = id;
        }
        public void AddQuantity(int increase)
        {
            Quantity += increase;
        } 
        public void RealseOrder(int number)
        {
            Quantity -= number;
        }
    }
}
