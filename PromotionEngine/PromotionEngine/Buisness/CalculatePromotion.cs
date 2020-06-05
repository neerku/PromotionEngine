using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PromotionEngine.Model;

namespace PromotionEngine.Buisness
{
    public class CalculatePromotion
    {
        public static List<CartItem> CreateCart(int a, int b, int c, int d)
        {
            var itemList = SKUItems();
            List<CartItem> items = new List<CartItem>()
            {
                new CartItem { Item=itemList.Where(x=>x.Id=="A").FirstOrDefault(),Quantity=a },
             new CartItem { Item=itemList.Where(x=>x.Id=="B").FirstOrDefault(),Quantity=b },
             new CartItem { Item=itemList.Where(x=>x.Id=="C").FirstOrDefault(),Quantity=c },
             new CartItem { Item=itemList.Where(x=>x.Id=="D").FirstOrDefault(),Quantity=d },
            };

            return items;
        }

        public static List<SKUItem> SKUItems()
        {
            List<SKUItem> items = new List<SKUItem>()
            {
                new SKUItem { Id = "A",Price = 50, PromotionalId = 1 },
                new SKUItem { Id = "B",Price = 30, PromotionalId = 2 },
                new SKUItem { Id = "C",Price = 20, PromotionalId = 3 },
                new SKUItem { Id = "D",Price = 15, PromotionalId = 3}
            };

            return items;
        }

        public int GetOrderValue(List<CartItem> cartItemList, List<Promotion> promotions)
        {
            var totalprice = 0;
            var typeAPromotionItemList = new List<CartItem>();
            var typeBPromotionItemList = new List<CartItem>();
            foreach (var cartItem in cartItemList)
            {
                var promotionType = promotions.Where(x => x.Id == cartItem.Item.PromotionalId).Select(x => x.PromotionType).FirstOrDefault();

                if (promotionType is PromotionTypeA)
                {
                    typeAPromotionItemList.Add(cartItem);
                }
                else
                {
                    typeBPromotionItemList.Add(cartItem);
                }
            }

            return totalprice;
        }
    }
}