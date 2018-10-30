using System;
using ECommerce.com.Common;
using ECommerce.com.Controller;
using ECommerce.com.Model;

namespace ECommerce.com
{
    class Program
    {
        static void Main(string[] args)
        {
            Category category = new Category("Food");
            Product apple = new Product("Apple", 100.0, category);
            Product almond = new Product("Almonds", 150.0, category);

            ShoppingCart cart = new ShoppingCart();
            cart.addItem(apple, 3);
            cart.addItem(almond, 1);

            Campaign campaign1 = new Campaign(category, 20.0, 3, DiscountType.Rate);
            Campaign campaign2 = new Campaign(category, 50.0, 5, DiscountType.Rate);
            Campaign campaign3 = new Campaign(category, 5.0, 5, DiscountType.Amount);

            cart.applyDiscounts(campaign1, campaign2, campaign3);

            Coupon coupon = new Coupon(100, 10, DiscountType.Rate);
            cart.applyCoupon(coupon);

            const double costPerDelivery = 1.0;
            const double costPerProduct = 1.0;
            const double fixedCost = 2.99;

            DeliveryCostCalculator deliveryCostCalculator = new DeliveryCostCalculator(costPerDelivery, costPerProduct, fixedCost);
            cart.DeliveryCost = deliveryCostCalculator.calculateFor(cart);

            cart.print();

            Console.ReadLine();
        }
    }
}
