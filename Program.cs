using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace LootBoxSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JObject jsObject = FileManager.GetData("Package-Items.json");
            string newJsonResult = JsonConvert.SerializeObject(jsObject, Formatting.Indented);
            PackageItemsStorage packageItems = new PackageItemsStorage();
            packageItems.load();
            LootGenerator gen = new LootGenerator(packageItems.Propabiliteis, packageItems.PropabiliteisItems);
            List<LootPool> lootPools = gen.generatePools();
            foreach (LootPool pool in lootPools)
            {
                pool.OpenBox();
            }
        }
    }
}
