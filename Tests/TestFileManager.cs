using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace LootBoxSystem.Tests
{
    internal class TestFileManager
    {
        [TestClass]
        class ItemTests
        {
            [TestMethod]
            public void TestMessageItems()
            {

                JObject jsObject = FileManager.GetData("Package-Items.json");
                Assert.AreEqual(jsObject[0], "poolConfig");
                Assert.AreEqual(jsObject[1], "items");
            }
        }
    }
}
