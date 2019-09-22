using csharp.Models;

namespace csharp.ItemStrategy.Strategies
{
    public class RegularItemStrategy :  IBaseStrategy
    {
        public int MinQuality { get; } = 0;
        public void UpdateQuality(Item item)
        {
            /*
             * Original implementation
             *
                if (item.Quality > 0)
                {
                    item.Quality -= 1;
                    if (item.SellIn <= 0 && item.Quality < 50)
                    {
                        item.Quality -= 1;
                    }
                }
             */

            item.Quality -= item.SellIn <= 0 ? 2 : 1;

            if (item.Quality < MinQuality)
            {
                item.Quality = MinQuality;
            }
        }
    }
}
