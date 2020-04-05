using System;
using System.Collections.Generic;
using System.Text;

namespace Course_work
{
    class Product
    {
        int Id;
        int Quantity;
        public Product()
        {

        }
        public Product(int id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }
        public int GetId
        {
            get
            {
                return Id;
            }
        }
        public int GetQuantity
        {
            get
            {
                return Quantity;
            }
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
