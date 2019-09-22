using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Models
{
    public class ItemStrategy 
    {
        public Item Item { get; set; }

        public IBaseStrategy Strategy { get; set; }

        public void UpdateQuality()
        {
            Strategy.UpdateQuality(Item);

            Item.SellIn -= 1;
        }

        public ItemStrategy(Item item)
        {
            Item = item;
        }
    }

    public interface IBaseStrategy
    {
        void UpdateQuality(Item item);
    }
}
