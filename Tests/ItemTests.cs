using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace LootBoxSystem.Tests
{
    [TestClass]
     class ItemTests
    {
      [TestMethod]
       public void TestMessageItems()
        {
            AItem coin = new Coin(3);
            Assert.AreEqual(coin.getValue(), "You got 3 coins.");
        }
    }
}
