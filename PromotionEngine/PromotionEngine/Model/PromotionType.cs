using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Model
{
    public abstract class PromotionType
    {
        public int Price { get; set; }
    }

    public class PromotionTypeA : PromotionType
    {
        public int Quantity { get; set; }
    }

    public class PromotionTypeB : PromotionType
    {
        public List<string> GroupedItems { get; set; }
    }
}