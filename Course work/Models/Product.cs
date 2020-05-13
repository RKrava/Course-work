using System;
using System.Collections.Generic;
using System.Text;

namespace Course_work
{
    public class Product
    {
        public string Title;
        public int Id { get; set; }
        public Product(int id, string title)
        {
            Id = id;
            Title = title;
        }
        public Product(Product product)
        {
            Title = product.Title;
            Id = product.Id;
        }
        public Product(int id)
        {
            Id = id;
        }
    }
}
