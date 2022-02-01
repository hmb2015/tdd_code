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
        public Item(string itemType, int itemQuantity, double itemPrice)
        {
            _itemQuantity = itemQuantity;
            _itemType = itemType;
            _itemPrice = itemPrice;
        }
        private int _itemQuantity { get; set; }
        private string _itemType { get; set; }
        private double _itemPrice { get; set; }


        public static double GetSingleItemTotalPrice(Item item)
        {
            return (item._itemQuantity * item._itemPrice);
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
        public double Total => _items.Aggregate(0, (double total, Item item) => total + Item.GetSingleItemTotalPrice(item));

    }
}
