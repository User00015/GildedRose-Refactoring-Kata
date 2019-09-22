using System.Linq;
using csharp.Strategy;

namespace csharp.Strategy.Strategies
{
    public class VariableItemStrategy : IBaseStrategy
    {
        public int MinQuality { get; } = 0;
        public void UpdateQuality(Item item)
        {
            item.Quality = GetRate(item);

            if (item.Quality < MinQuality)
            {
                item.Quality = MinQuality;
            }
        }

        private int GetRate(Item item)
        {
            if (item.SellIn <= 0) return 0;
            if (item.SellIn <= 5) return item.Quality + 3;
            if (item.SellIn <= 10) return item.Quality + 2;
            return item.Quality + 1;
        }
    }
}
