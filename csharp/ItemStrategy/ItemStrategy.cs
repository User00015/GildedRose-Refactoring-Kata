using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Strategy
{
    public class ItemStrategy 
    {
        public ItemStrategy(Item item)
        {
            _item = item;
        }

        private Item _item { get; set; }

        public IBaseStrategy Strategy { get; set; }

        public void UpdateQuality()
        {
            Strategy.UpdateQuality(_item);

            _item.SellIn -= 1;
        }

    }

    public interface IBaseStrategy
    {
        void UpdateQuality(Item item);
    }
}
