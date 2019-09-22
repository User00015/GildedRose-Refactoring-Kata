using csharp.Models;

namespace csharp.ItemStrategy.Strategies
{
    public class AgedItemStrategy :  IBaseStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;

                if (item.SellIn <= 0 && item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }
        }
    }
}
