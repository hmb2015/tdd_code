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
            //Arrange
            List<Item> testItems = new List<Item>();

            //ACT
            Cart items = new Cart(testItems);

            //ASSERT
            Assert.AreEqual(0.0, items.Total);
        }

        [TestMethod]
        public void CheckPriceOfOneItem()
        {
            //Arrange
            List<Item> testItems = new List<Item> { new Item("A", 1) };

            //ACT
            Cart items = new Cart(testItems);

            //ASSERT
            Assert.AreEqual(50.0, items.Total);
        }

        [TestMethod]
        public void CheckPriceOfMultipleItems()
        {
            //Arrange
            List<Item> testItems = new List<Item> { new Item("A", 1), new Item("B", 2) };

            //ACT
            Cart items = new Cart(testItems);

            //ASSERT
            Assert.AreEqual(110.0, items.Total);
        }

        [TestMethod]
        public void CheckPriceOfItemsNotAvailable()
        {
            //Arrange
            List<Item> testItems = new List<Item> { new Item("E", 1), new Item("G", 2) };

            //ACT
            Cart items = new Cart(testItems);

            //ASSERT
            Assert.AreEqual(0.0, items.Total);
        }

        [TestMethod]
        public void CheckPromotionPriceOfMultipleItems_Fail()
        {
            //Arrange
            List<Item> testItems = new List<Item> { new Item("A", 1), new Item("B", 2) };

            //ACT
            Cart items = new Cart(testItems);

            //ASSERT
            Assert.AreNotEqual(110.0, items.TotalAfterPromotions);
        }

        [TestMethod]
        public void CheckPromotionPriceOfMultipleItemsABOnly()
        {
            //Arrange
            List<Item> testItems = new List<Item> { new Item("A", 1), new Item("B", 1) };

            //ACT
            Cart items = new Cart(testItems);

            //ASSERT
            Assert.AreEqual(80.0, items.TotalAfterPromotions);
        }

        [TestMethod]
        public void CheckPromotionPriceOfMultipleItemsABCOnly()
        {
            //Arrange
            List<Item> testItems = new List<Item> { new Item("A", 5), new Item("B", 6), new Item("C", 6) };

            //ACT
            Cart items = new Cart(testItems);

            //ASSERT
            Assert.AreEqual(485.0, items.TotalAfterPromotions);
        }

        [TestMethod]
        public void CheckPromotionPriceOfMultipleItemsABDOnly()
        {
            //Arrange
            List<Item> testItems = new List<Item> { new Item("A", 5), new Item("B", 6), new Item("D", 6) };

            //ACT
            Cart items = new Cart(testItems);

            //ASSERT
            Assert.AreEqual(455.0, items.TotalAfterPromotions);
        }
    }
}
