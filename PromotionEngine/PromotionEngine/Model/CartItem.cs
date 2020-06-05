using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Model
{
    public class CartItem
    {
        public SKUItem Item { get; set; }

        public int Quantity { get; set; }
    }
}