using ECommerce.com.Model;

namespace ECommerce.com.Controller
{
    public class DeliveryCostCalculator
    {
        public double CostPerDelivery { get; set; }
        public double CostPerProduct { get; set; }
        public double FixedCost { get; set; }

        public DeliveryCostCalculator(double costPerDelivery, double costPerProduct, double fixedCost)
        {
            CostPerDelivery = costPerDelivery;
            CostPerProduct = costPerProduct;
            FixedCost = fixedCost;
        }

        public double calculateFor(ShoppingCart shoppingCart)
        {
            return (CostPerDelivery * shoppingCart.calculateNumberOfDeliveries() + CostPerProduct) + (shoppingCart.calculateNumberOfProducts()) + FixedCost;
        }
    }
}
