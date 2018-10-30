using ECommerce.com.Common;

namespace ECommerce.com.Model
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public double MinimumAmount { get; set; }
        public double DiscountAmount { get; set; }
        public DiscountType DiscountType { get; set; }

        public Coupon(double minimumAmount, double discountAmount, DiscountType discountType)
        {
            MinimumAmount = minimumAmount;
            DiscountAmount = discountAmount;
            DiscountType = discountType;
        }
    }
}
