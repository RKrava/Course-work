namespace Course_work.Models
{
    public class OrderProduct // клас для полегшенної роботи з продуктами і кількостю їх для замовлення
    {
        #region Properties
        public Product Product { get; set; } 
        public int QuantityToOrder { get; set; }
        #endregion
        public OrderProduct(Product product, int quantityToOrder)
        {
            Product = product;
            QuantityToOrder = quantityToOrder;
        }
    }
}
