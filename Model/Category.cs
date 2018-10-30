using ECommerce.com.Common;

namespace ECommerce.com.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Title { get; set; }

        public Category(string Title)
        {
            this.Title = Title;
        }

        public double calculateCampaignDiscount(ShoppingCart shoppingCart, double minimumAmount, double discountAmount, DiscountType discountType)
        {
            if (shoppingCart.getTotalAmount() < minimumAmount)
            {
                return shoppingCart.getTotalAmount();
            }

            double totalAmountAfterCampaigns = shoppingCart.getTotalAmount() - shoppingCart.getCampaignDiscount();

            if (discountType.Equals(DiscountType.Amount))
            {
                return totalAmountAfterCampaigns - discountAmount;
            }
            else
            {
                return totalAmountAfterCampaigns * (1 - discountAmount);
            }
        }
    }
}
