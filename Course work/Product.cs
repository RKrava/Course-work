using System;
using System.Collections.Generic;
using System.Text;

namespace Course_work
{
    class Product
    {
        string Title;
        public Product(int id, int quantity, string title)
        {
            Id = id;
            Quantity = quantity;
            Title = title;
        }
        public int Id { get; set; }
        public int Quantity { get; set; }
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
