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

        [TestMethod]
        public void CheckPriceOfOneItem()
        {
            Cart items = new Cart(new List<Item> { new Item("A", 1)});
            Assert.AreEqual(50.0, items.Total);
        }

        [TestMethod]
        public void CheckPriceOfMultipleItems()
        {
            Cart items = new Cart(new List<Item> { new Item("A", 1), new Item("B", 2) });
            Assert.AreEqual(110.0, items.Total);
        }

        [TestMethod]
        public void CheckPriceOfItemsNotAvailable()
        {
            Cart items = new Cart(new List<Item> { new Item("E", 1), new Item("G", 2) });
            Assert.AreEqual(0.0, items.Total);
        }

        [TestMethod]
        public void CheckPromotionPriceOfMultipleItems_Fail()
        {
            Cart items = new Cart(new List<Item> { new Item("A", 1), new Item("B", 2) });
            Assert.AreNotEqual(110.0, items.TotalAfterPromotions);
        }

        [TestMethod]
        public void CheckPromotionPriceOfMultipleItems1()
        {
            Cart items = new Cart(new List<Item> { new Item("A", 1), new Item("B", 2) });
            Assert.AreEqual(95.0, items.TotalAfterPromotions);
        }
    }
}
