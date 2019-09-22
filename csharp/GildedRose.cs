using System.Collections.Generic;
using csharp.Strategy.Strategies;
using csharp.Strategy;

namespace csharp
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string ConcertTickets = "Backstage passes to a TAFKAL80ETC concert";
        private const string Conjured = "Conjured Mana Cake";

        readonly IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var updateSolver = new ItemStrategy(item);

                /*
                 * First iteration: Simple chain of if else to supply each strategy in turn.
                 *

                if(item.Name == AgedBrie) updateSolver.Strategy = new AgedItemStrategy();
                else if(item.Name == Sulfuras) updateSolver.Strategy = new LegendaryItemStrategy();
                else if(item.Name == ConcertTickets) updateSolver.Strategy = new VariableItemStrategy();
                else updateSolver.Strategy = new RegularItemStrategy();

                 */


                //This can be abstracted further into a Director or Rules pattern, where a layer of abstraction makes this determination for us instead of calculating it here.
                switch (item.Name)
                {
                    case AgedBrie:
                        updateSolver.Strategy = new AgedItemStrategy();
                        break;
                    case Sulfuras:
                        updateSolver.Strategy = new LegendaryItemStrategy();
                        break;
                    case ConcertTickets:
                        updateSolver.Strategy = new VariableItemStrategy();
                        break;
                    case Conjured:
                        updateSolver.Strategy = new ConjuredItemStrategy();
                        break;
                    default:
                        updateSolver.Strategy = new RegularItemStrategy();
                        break;
                }

                updateSolver.UpdateQuality();
            }
        }
    }
}
