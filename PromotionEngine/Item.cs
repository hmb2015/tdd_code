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

        private List<string> GetMultipleEligibleTypesForPromotion(List<PromotionalPrice> activePromotions)
        {
            List<string> eligibleItems = new List<string>();

            foreach (var item in activePromotions)
            {
                if(item.ItemType.Contains("|"))
                {
                    eligibleItems.AddRange(item.ItemType.Split("|").ToList());
                }
            }

            return eligibleItems.Distinct().ToList();                
        }

        public double GetTotalPromotionalPriceForAllItems(List<Item> items)
        {
            double totalPrice = 0.0;

            List<Item> multipleEligiblePromotionItems = GetMultipleEligibleItemsForPromotion(items).OrderBy(i => i._itemQuantity).ToList();

            //totalPrice += 
            foreach (var item in multipleEligiblePromotionItems)
            {

            }

            return totalPrice;
        }

        private List<Item> GetMultipleEligibleItemsForPromotion(List<Item> items)
        {
            List<string> eligibleItemsForPromotion = GetMultipleEligibleTypesForPromotion(PriceAndPromotions.ActivePromotions);

            var itemsEligibleForMultiPromo = (from i in items
                                              where eligibleItemsForPromotion.Any(e => i._itemType == e)
                                              select i).ToList();

            return (itemsEligibleForMultiPromo.Count == eligibleItemsForPromotion.Count) ? itemsEligibleForMultiPromo : new List<Item>();
        }
    }
}
