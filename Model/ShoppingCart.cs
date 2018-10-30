using System;
using System.Collections.Generic;
using ECommerce.com.Common;

namespace ECommerce.com.Model
{
    public class ShoppingCart
    {
        public double CampaignDiscountAmount { get; set; }
        public double CartDiscountAmount { get; set; }
        public double TotalAmount { get; set; }
        public double DeliveryCost { get; set; }
        public Dictionary<Product, double> Items { get; set; }

        public ShoppingCart()
        {
            Items = new Dictionary<Product, double>();
        }

        public bool addItem(Product product, double quantity)
        {
            if (quantity > product.GetAvailableProductQuantity())
            {
                return false;
            }

            product.BookProduct(quantity);
            
            if (Items != null && Items.ContainsKey(product))
            {
                Items[product] = Items[product] + quantity;
            }
            else
            {
                Items.Add(product, quantity);
            }

            return true;
        }

        public double getTotalAmount()
        {
            double totalAmount = 0.0;
            List<Product> productList = new List<Product>(Items.Keys);
            List<double> quantityList = new List<double>(Items.Values);

            for (int i = 0; i < Items.Count; i++)
            {
                totalAmount += productList[i].Price * quantityList[i];
            }

            return totalAmount;
        }

        public void applyCoupon(Coupon coupon)
        {
            if (getTotalAmount() < coupon.MinimumAmount)
            {
                CartDiscountAmount = getTotalAmount();
            }

            double totalAmountAfterCampaigns = getTotalAmount() - getCampaignDiscount();

            if (coupon.DiscountType.Equals(DiscountType.Amount))
            {
                CartDiscountAmount = coupon.DiscountAmount;
            }
            else
            {
                CartDiscountAmount = totalAmountAfterCampaigns * coupon.DiscountAmount;
            }
        }

        public int calculateNumberOfDeliveries()
        {
            HashSet<int> uniqueCategories = new HashSet<int>();
            List<Product> productList = new List<Product>(Items.Keys);

            for (int i = 0; i < productList.Count; i++)
            {
                uniqueCategories.Add(productList[i].Category.CategoryId);
            }

            return uniqueCategories.Count;
        }

        public int calculateNumberOfProducts()
        {
            HashSet<int> uniqueProducts = new HashSet<int>();
            List<Product> productList = new List<Product>(Items.Keys);

            for (int i = 0; i < productList.Count; i++)
            {
                uniqueProducts.Add(productList[i].ProductId);
            }

            return uniqueProducts.Count;
        }

        public double getTotalAmountAfterDiscounts()
        {
            return getTotalAmount() - getCampaignDiscount() - getCouponDiscount();
        }

        private double getCouponDiscount()
        {
            return CartDiscountAmount;
        }

        public double getCampaignDiscount()
        {
            return CampaignDiscountAmount;
        }

        public double calculateCampaignDiscount(Campaign campaign)
        {
            double totalDiscount = 0.0;
            List<Product> productList = new List<Product>(Items.Keys);
            List<double> quantityList = new List<double>(Items.Values);

            for (int i = 0; i < Items.Count; i++)
            {
                if (productList[i].Category == campaign.Category && quantityList[i] >= campaign.MinimalAmount)
                {
                    totalDiscount += productList[i].Price * quantityList[i];
                }
            }

            if (campaign.DiscountType == DiscountType.Amount)
            {
                CampaignDiscountAmount = campaign.DiscountAmount;
            }
            else
            {
                CampaignDiscountAmount = totalDiscount * campaign.DiscountAmount;
            }

            return CampaignDiscountAmount;
        }

        public double applyDiscounts(Campaign campaign1, Campaign campaign2, Campaign campaign3)
        {
            double campaign1Discount = calculateCampaignDiscount(campaign1);
            double campaign2Discount = calculateCampaignDiscount(campaign2);
            double campaign3Discount = calculateCampaignDiscount(campaign3);

            if (campaign1Discount > campaign2Discount)
            {
                if (campaign1Discount > campaign3Discount)
                {
                    return campaign1Discount;
                }
                else
                {
                    return campaign3Discount;
                }
            }
            else
            {
                if (campaign2Discount > campaign3Discount)
                {
                    return campaign2Discount;
                }
                else
                {
                    return campaign3Discount;
                }
            }
        }

        public void print()
        {
            Console.WriteLine("Total amount is {0}, The delivery cost is {1}", getTotalAmountAfterDiscounts(), DeliveryCost);
        }
    }
}
