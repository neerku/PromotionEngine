﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PromotionEngine.Model;

namespace PromotionEngine.Buisness
{
    public class CalculatePromotion
    {
        public static int CalculateTypeAPromotionCost(Dictionary<CartItem, PromotionTypeA> cartItems)
        {
            var totalPrice = 0;
            foreach (var cartItem in cartItems)
            {
                if (cartItem.Key.Quantity >= cartItem.Value.Quantity)
                {
                    var modQuantity = cartItem.Key.Quantity % cartItem.Value.Quantity;
                    if (modQuantity == 0)
                    {
                        var price = (cartItem.Key.Quantity / cartItem.Value.Quantity) * cartItem.Value.Price;
                        totalPrice += price;
                    }
                    else
                    {
                        var remainingprice = modQuantity * cartItem.Key.Item.Price;
                        totalPrice += remainingprice;
                        var groupPrice = (cartItem.Key.Quantity / cartItem.Value.Quantity) * cartItem.Value.Price;
                        totalPrice += groupPrice;
                    }
                }
                else
                {
                    var price = cartItem.Key.Quantity * cartItem.Key.Item.Price;
                    totalPrice += price;
                }
            }
            return totalPrice;
        }

        public static int CalculateTypeBPromotionCost(Dictionary<CartItem, PromotionTypeB> cartItems)
        {
            var totalPrice = 0;
            var itemsCalculated = new Dictionary<CartItem, PromotionTypeB>();
            foreach (var item in cartItems)
            {
                var groupedItems = cartItems.Keys.Where(x => item.Value.GroupedItems.Contains(x.Item.Id)).ToList();
                if (itemsCalculated.Count > 0 && groupedItems.Count > 0)
                {
                    foreach (var calculateditem in itemsCalculated)
                        groupedItems.Remove(calculateditem.Key);
                }
                if (groupedItems.Any())
                {
                    var item1count = groupedItems.First().Quantity;
                    var item2Count = groupedItems.Last().Quantity;
                    if (item1count == item2Count)
                    {
                        totalPrice += item.Value.Price * item1count;
                    }
                    else if (item1count > item2Count)
                    {
                        var remainingquant = item1count - item2Count;
                        totalPrice += remainingquant * groupedItems.First().Item.Price;
                        totalPrice += item2Count * item.Value.Price;
                    }
                    else
                    {
                        var remainingquant = item2Count - item1count;
                        totalPrice += remainingquant * groupedItems.Last().Item.Price;
                        totalPrice += item1count * item.Value.Price;
                    }

                    foreach (var cartItem in groupedItems)
                    {
                        itemsCalculated.Add(cartItem, item.Value);
                    }
                }
            }
            return totalPrice;
        }

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
            var typeAPromotionItemList = new Dictionary<CartItem, PromotionTypeA>();
            var typeBPromotionItemList = new Dictionary<CartItem, PromotionTypeB>();
            foreach (var cartItem in cartItemList)
            {
                var promotionType = promotions.Where(x => x.Id == cartItem.Item.PromotionalId).Select(x => x.PromotionType).FirstOrDefault();

                if (promotionType is PromotionTypeA)
                {
                    typeAPromotionItemList.Add(cartItem, (PromotionTypeA)promotionType);
                }
                else
                {
                    typeBPromotionItemList.Add(cartItem, (PromotionTypeB)promotionType);
                }
            }

            totalprice += CalculateTypeAPromotionCost(typeAPromotionItemList);
            totalprice += CalculateTypeBPromotionCost(typeBPromotionItemList);

            return totalprice;
        }
    }
}