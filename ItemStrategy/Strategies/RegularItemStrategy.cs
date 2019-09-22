using csharp.Models;

namespace csharp.ItemStrategy.Strategies
{
    public class RegularItemStrategy :  IBaseStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
                if (item.SellIn <= 0 && item.Quality < 50)
                {
                    item.Quality -= 1;
                }
            }
        }
    }
}
