using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class Item
    {
        public Item(string itemType, int itemQuantity)
        {
            _itemQuantity = itemQuantity;
            _itemType = itemType;
        }
        private int _itemQuantity { get; set; }
        private string _itemType { get; set; }

        public double GetSingleItemTotalPrice(Item item)
        {
            return (item._itemQuantity * (PriceAndPromotions.ItemPriceList.ContainsKey(item._itemType) ? PriceAndPromotions.ItemPriceList[item._itemType] : 0.0));
        }

        public double GetPromotionalPriceByItem(Item item)
        {
            double itemEffectivePrice = 0.0;
            var actPromotionForItem = PriceAndPromotions.ActivePromotions.Single(p => p.ItemType == item._itemType);

            if (item._itemQuantity >= actPromotionForItem.ItemQuantity)
            {
                var quotient = item._itemQuantity / actPromotionForItem.ItemQuantity;
                var remainder = item._itemQuantity % actPromotionForItem.ItemQuantity;
                itemEffectivePrice = (quotient * actPromotionForItem.ItemPromotionalPrice) + (remainder * PriceAndPromotions.ItemPriceList[item._itemType]);
            }
            else
            {
                itemEffectivePrice = GetSingleItemTotalPrice(item);
            }

            return itemEffectivePrice;
        }
    }
}
