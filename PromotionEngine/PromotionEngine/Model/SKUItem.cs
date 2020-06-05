using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Model
{
    public class SKUItem
    {
        public string Id { get; set; }

        public int Price { get; set; }

        public int PromotionalId { get; set; }
    }
}