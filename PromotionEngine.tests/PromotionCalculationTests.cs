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
            Cart items = new Cart(new List<Item> { new Item("A", 1, 50.0)});
            Assert.AreEqual(50.0, items.Total);
        }

        [TestMethod]
        public void CheckPriceOfMultipleItems()
        {
            Cart items = new Cart(new List<Item> { new Item("A", 1, 50.0), new Item("B", 2, 30.0) });
            Assert.AreEqual(110.0, items.Total);
        }

    }
}
