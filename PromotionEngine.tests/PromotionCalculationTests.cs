using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PromotionEngine.tests
{
    [TestClass]
    public class PromotionCalculationTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod]
        public void CheckCartIsEmpty()
        {
            Cart items = new Cart(new List<Item>());
            Assert.AreEqual(0.0, items.Total);
        }
    }

    public class Item
    {
        public string ItemType { get; set; }
        public int ItemPrice { get; set; }
    }

    public class Cart
    {
        public Cart(List<Item> lists)
        {
            
        }

        public double Total => 0.0;
    }
}
