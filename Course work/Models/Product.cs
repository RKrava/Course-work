namespace Course_work
{
    public class Product // клас який характирезує Продукт
    {
        #region Properties
        public string Title; // ім'я продукту
        public int Id { get; set; } // Айди продукту
        #endregion
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
