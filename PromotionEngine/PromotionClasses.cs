using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine
{
    public class PromotionClasses
    {

    }
    public class Item
    {
        public Item(string itemType, int itemQuantity)
        {
            _itemQuantity = itemQuantity;
            _itemType = itemType;
        }
        private int _itemQuantity { get; set; }
        private string _itemType { get; set; }

        Dictionary<string, double> _itemPriceList = new Dictionary<string, double>()
        {
            { "A", 50.0 }, { "B", 30.0 }, { "C", 20.0 }, { "D", 15.0 }
        };

        List<PromotionalPrice> activePromotions = new List<PromotionalPrice>
        {
            new PromotionalPrice("A", 3, 130.0),
            new PromotionalPrice("B", 2, 45.0),
            new PromotionalPrice("C", 1, 0.0),
            new PromotionalPrice("D", 1, 15.0),
        };

        public double GetSingleItemTotalPrice(Item item)
        {
            return (item._itemQuantity * (_itemPriceList.ContainsKey(item._itemType) ? _itemPriceList[item._itemType] : 0.0));
        }


        public double GetPromotionalPrice(List<Item> items)
        {
            double totalPromotionPrice = 0.0;

            foreach (var item in items)
            {

            }

            return totalPromotionPrice;
        }
    }

    public class PromotionalPrice
    {
        private int _itemQuantity { get; set; }
        private string _itemType { get; set; }
        private double _itemPromotionalPrice { get; set; }

        public PromotionalPrice(string itemType, int itemQuantity, double itemPromotionalPrice)
        {
            _itemType = itemType;
            _itemQuantity = itemQuantity;
            _itemPromotionalPrice = itemPromotionalPrice;
        }
    }

    public class Cart
    {
        private List<Item> _items;

        public Cart(List<Item> items)
        {
            _items = items;
        }

        //public double Total => _items.Count > 0 ? (_items[0].ItemPrice * _items[0].ItemQuantity): 0.0;
        public double Total => _items.Aggregate(0, (double total, Item item) => total + item.GetSingleItemTotalPrice(item));

        public double TotalAfterPromotions => _items.Aggregate(0, (double totalAfterPromotions, Item item) => totalAfterPromotions + item.GetPromotionalPrice(_items));

    }
}
