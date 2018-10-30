using ECommerce.com.Common;

namespace ECommerce.com.Model
{
    public class Campaign
    {
        public int CampaignId { get; set; }
        public double DiscountAmount { get; set; }
        public double MinimalAmount { get; set; }
        public Category Category { get; set; }
        public DiscountType DiscountType { get; set; }

        public Campaign(Category category, double discountAmount, int minimmalAmount, DiscountType discountType)
        {
            Category = category;
            DiscountAmount = discountAmount;
            MinimalAmount = minimmalAmount;
            DiscountType = discountType;
        }
    }
}
