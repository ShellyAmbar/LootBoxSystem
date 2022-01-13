using Newtonsoft.Json.Linq;
using System;


namespace LootBoxSystem
{
    internal class PackageItemsStorage
    {

        private string[] propabiliteis;
        private JObject propabiliteisItems;


        public void load()
        {
            loadItemsAndpropabiliteis();
        }
        private void loadItemsAndpropabiliteis()
        {
            JObject jsObject = FileManager.GetData("Package-Items.json");
            this.propabiliteis = null;
            if (jsObject != null)
            {
                if (jsObject.ContainsKey("poolConfig"))
                {
                    JObject poolConfig = (JObject)jsObject.GetValue("poolConfig");
                    if (poolConfig.ContainsKey("propabiliteis"))
                    {
                        loadPropabilities(poolConfig);
                        Console.WriteLine("Done loading!");

                    }
                    if (poolConfig.ContainsKey("propabiliteisItems"))
                    {
                        loadPropabilitiesItems(poolConfig);
                        Console.WriteLine("Done loading!");
                    }
                        

                }

            }
        }

        private void loadPropabilities(JObject poolConfig)
        {
            JArray propabiliteisArray = (JArray)poolConfig.GetValue("propabiliteis");
            this.propabiliteis = propabiliteisArray.ToObject<string[]>();
        }

        private void loadPropabilitiesItems(JObject poolConfig)
        {
            this.propabiliteisItems = (JObject)poolConfig.GetValue("propabiliteisItems");
        }

        public string[] Propabiliteis
        {
            get { return propabiliteis; }
            set { propabiliteis = value;}
        }

        public JObject PropabiliteisItems
        {
            get { return propabiliteisItems; }
            set { propabiliteisItems = value; }
        }



    }
}
