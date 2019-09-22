using csharp.Models;

namespace csharp.ItemStrategy.Strategies
{
    public class ConjuredItemStrategy : IBaseStrategy
    {
        public int MinQuality { get; } = 0;

        public void UpdateQuality(Item item)
        {
            /*
             * Original implementation
             *
             *
                if (item.Quality > 0)
                {
                    item.Quality -= 2;
                    if (item.SellIn <= 0 && item.Quality > 4)
                    {
                        item.Quality -= 2;
                    }
                    else if(item.SellIn <= 0 && item.Quality < 4 && item.Quality > 0)
                    {
                        item.Quality = 0;
                    }
                }

             *
             *
             */

            item.Quality -= item.SellIn <= 0 ? 4 : 2;

            if (item.Quality < MinQuality)
            {
                item.Quality = MinQuality;
            }
        }
    }
}