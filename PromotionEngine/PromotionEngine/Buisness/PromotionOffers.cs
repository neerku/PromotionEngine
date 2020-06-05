using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionEngine.Model;

namespace PromotionEngine.Buisness
{
    public class PromotionOffers
    {
        public static List<Promotion> CreatePromotion()
        {
            List<Promotion> promotions = new List<Promotion>()
            {
                new Promotion { Id = 1, PromotionType = new PromotionTypeA{ Quantity=3,Price=130} },
               new Promotion { Id = 2, PromotionType = new PromotionTypeA{ Quantity=2,Price=45} },
               new Promotion { Id = 3, PromotionType = new PromotionTypeB{
               Price=30,GroupedItems=new List<string>{"C","D"}}},
            };

            return promotions;
        }
    }
}