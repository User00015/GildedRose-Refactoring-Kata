using csharp.Models;

namespace csharp.ItemStrategy.Strategies
{
    public class ConjuredItemStrategy : IBaseStrategy
    {
        public void UpdateQuality(Item item)
        {
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
        }
    }
}