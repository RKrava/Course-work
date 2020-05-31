namespace Course_work.Models
{
    public class Pair<T, U> // клас який ми використовуємо для зберігання одразу двох елементів данних (продукту та кількості)
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        #region Properties
        public T First { get; set; } // перший елемент
        public U Second { get; set; } // другий елемент
        #endregion
    }
}
