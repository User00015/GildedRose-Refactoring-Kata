using csharp.Models;

namespace csharp.ItemStrategy.Strategies
{
    public class AgedItemStrategy : IBaseStrategy
    {
        public int MaxQuality { get; } = 50;

        public void UpdateQuality(Item item)
        {
            item.Quality += item.SellIn <= 0 ? 2 : 1;

            if (item.Quality > MaxQuality)
            {
                item.Quality = MaxQuality;
            }
        }
    }
}
