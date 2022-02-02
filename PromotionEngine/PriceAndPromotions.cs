using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public static class PriceAndPromotions
    {
        public static Dictionary<string, double> ItemPriceList = new Dictionary<string, double>()
        {
            { "A", 50.0 }, { "B", 30.0 }, { "C", 20.0 }, { "D", 15.0 }
        };

        public static List<PromotionalPrice> ActivePromotions = new List<PromotionalPrice>
        {
            new PromotionalPrice("A", 3, 130.0),
            new PromotionalPrice("B", 2, 45.0),
            new PromotionalPrice("C", 1, 20.0),
            new PromotionalPrice("D", 1, 15.0),
            new PromotionalPrice("C|D", 1, 30.0),
        };
    }
}
