
namespace ECommerce.com.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double OnCart { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public Product(string title, double quantity, Category category)
        {
            Title = title;
            Quantity = quantity;
            Category = category;
        }

        public double GetAvailableProductQuantity()
        {
            return Quantity - OnCart;
        }

        public void BookProduct(double quantity)
        {
            OnCart = OnCart + quantity;
        }
    }
}
