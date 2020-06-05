using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Buisness;

namespace PromotionEngineTest
{
    [TestClass]
    public class TestPromotion
    {
        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        public void TestScenarioA()
        {
            var cp = new CalculatePromotion();
            var cart = CalculatePromotion.CreateCart(1, 1, 1, 0);
            var promo = PromotionOffers.CreatePromotion();
            var totalprice = cp.GetOrderValue(cart, promo);

            Assert.AreEqual(totalprice, 100);
        }

        [TestMethod]
        public void TestScenarioB()
        {
            var cp = new CalculatePromotion();
            var cart = CalculatePromotion.CreateCart(5, 5, 1, 0);
            var promo = PromotionOffers.CreatePromotion();
            var totalprice = cp.GetOrderValue(cart, promo);

            Assert.AreEqual(totalprice, 370);
        }

        [TestMethod]
        public void TestScenarioC()
        {
            var cp = new CalculatePromotion();
            var cart = CalculatePromotion.CreateCart(3, 5, 1, 1);
            var promo = PromotionOffers.CreatePromotion();
            var totalprice = cp.GetOrderValue(cart, promo);

            Assert.AreEqual(totalprice, 280);
        }

        [TestMethod]
        public void TestScenarioD()
        {
            var cp = new CalculatePromotion();
            var cart = CalculatePromotion.CreateCart(30, 50, 25, 20);
            var promo = PromotionOffers.CreatePromotion();
            var totalprice = cp.GetOrderValue(cart, promo);

            Assert.AreEqual(totalprice, 3125);
        }
    }
}