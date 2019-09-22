using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        private const string AgedBrie = "Aged Brie";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string ConcertTickets = "Backstage passes to a TAFKAL80ETC concert";
        private const string Conjured = "Conjured Mana Cake";
        [Test]
        public void CanCreateItem()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void RegularItemDecaysByOneAfterASingleDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(20, Items[0].Quality);
            Assert.AreEqual(10, Items[0].SellIn);
            app.UpdateQuality();
            Assert.AreEqual(19, Items[0].Quality);
            Assert.AreEqual(9, Items[0].SellIn);
        }

        [Test]
        public void RegularItemDecaysByTwoAfterSellInExpires()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 3, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(20, Items[0].Quality);
            Assert.AreEqual(3, Items[0].SellIn);
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.AreEqual(17, Items[0].Quality);
            Assert.AreEqual(0, Items[0].SellIn);
            app.UpdateQuality();
            Assert.AreEqual(15, Items[0].Quality);
        }

        [Test]
        public void AgedItemsIncreaseByOneBeforeSellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = AgedBrie, SellIn = 3, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(0, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(1, Items[0].Quality);
        }
        [Test]
        public void AgedItemsIncreaseByTwoAfterSellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = AgedBrie, SellIn = 3, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(0, Items[0].Quality);
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.AreEqual(3, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(5, Items[0].Quality);
        }
        [Test]
        public void LegendaryItemsNeverChange()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Sulfuras, SellIn = 10, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(80, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(80, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(80, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(80, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(80, Items[0].Quality);
        }

        [Test]
        public void LegendaryItemsCanBeAboveFiftyQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Sulfuras, SellIn = 10, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(80, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(80, Items[0].Quality);
        }

        [Test]
        public void AgedItemsCanNeverBeAboveFiftyQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = AgedBrie, SellIn = 10, Quality = 48 } };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(48, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(49, Items[0].Quality);
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void RegularItemsCanNeverDropBelowZeroQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Regular Item", SellIn = 10, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(3, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].Quality);
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void ConcertTicketsIncreaseByOneWhenSellInIsLaterThanTen()
        {
            IList<Item> Items = new List<Item> { new Item { Name = ConcertTickets, SellIn = 11, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(20, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(21, Items[0].Quality);
        }
        [Test]
        public void ConcertTicketsIncreaseByTwoWhenSellInIsLessThanTen()
        {
            IList<Item> Items = new List<Item> { new Item { Name = ConcertTickets, SellIn = 10, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(20, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(22, Items[0].Quality);
        }

        [Test]
        public void ConcertTicketsIncreaseByThreeWhenSellInIsLessThanFive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = ConcertTickets, SellIn = 6, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(20, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(22, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(25, Items[0].Quality);
        }

        [Test]
        public void ConcertTicketsAreWorthlessAfterSellInPasses()
        {
            IList<Item> Items = new List<Item> { new Item { Name = ConcertTickets, SellIn = 2, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(20, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(23, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(26, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void ConcertTicketsNeverDropBelowZeroQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = ConcertTickets, SellIn = 1, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(20, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(23, Items[0].Quality);
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void ConjuredItemsDecayTwiceAsFastBeforeSellInPasses()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Conjured, SellIn = 3, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(20, Items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(18, Items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(16, Items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(14, Items[0].Quality);
        }

        [Test]
        public void ConjuredItemsDecayFourTimesAsFastAfterSellInPasses()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Conjured, SellIn = 1, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(20, Items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(18, Items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(14, Items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(10, Items[0].Quality);
        }

        [Test]
        public void ConjuredItemsDecayToZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Conjured, SellIn = 1, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            Assert.AreEqual(5, Items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(3, Items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

    }
}
