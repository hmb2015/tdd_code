
namespace PromotionEngine
{
    public class PromotionalPrice
    {
        public int ItemQuantity { get; set; }
        public string ItemType { get; set; }
        public double ItemPromotionalPrice { get; set; }

        public PromotionalPrice(string itemType, int itemQuantity, double itemPromotionalPrice)
        {
            ItemType = itemType;
            ItemQuantity = itemQuantity;
            ItemPromotionalPrice = itemPromotionalPrice;
        }
    }
}
