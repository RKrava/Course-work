namespace Course_work.Models
{
    public class OrderProduct
    {
        public OrderProduct(Product product, int quantityToOrder)
        {
            Product = product;
            QuantityToOrder = quantityToOrder;
        }
        public Product Product { get; set; }
        public int QuantityToOrder { get; set; }
    }
}
