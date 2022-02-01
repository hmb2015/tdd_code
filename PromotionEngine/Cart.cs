using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine
{
    public class Cart
    {
        private List<Item> _items;

        public Cart(List<Item> items)
        {
            _items = items;
        }

        public double Total => _items.Aggregate(0, (double total, Item item) => total + item.GetSingleItemTotalPrice(item));

        public double TotalAfterPromotions => _items.Aggregate(0, (double totalAfterPromotions, Item item) => totalAfterPromotions + item.GetPromotionalPriceByItem(item));

    }
}
