using csharp.Models;

namespace csharp.ItemStrategy.Strategies
{
    public class VariableItemStrategy : IBaseStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;

                if (item.Quality < 50)
                {
                    if (item.SellIn <= 0)
                    {
                        item.Quality = 0;
                    }
                    else if (item.SellIn <= 5)
                    {
                        item.Quality += 2;
                    }
                    else if (item.SellIn <= 10)
                    {
                        item.Quality += 1;
                    }
                }
            }
        }
    }
}
