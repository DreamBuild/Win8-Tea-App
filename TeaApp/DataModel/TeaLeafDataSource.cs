
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace TeaApp.DataModel
{
    public class TeaLeafDataSource
    {
        private static List<TeaLeafItem> items = new List<TeaLeafItem>();

        public async Task<List<TeaLeafItem>> GetItems()
        {
            if(items.Count == 0)
            {
                await LoadItemsAsync();
            }

            return items;
        }

        private async Task LoadItemsAsync()
        {
            JsonArray array = await JsonArrayReader.ReadArrayFromFile("TalkTea/tealeafs.json");

            TeaLeafItem item = null;
            JsonObject obj = null;

            for (int i = 0; i < array.Count; i++)
            {
                obj = array[i].GetObject();
                if(obj != null)
                {
                    item = new TeaLeafItem();
                    item.Name = obj["name"].GetString();
                    item.Address = obj["content"].GetString();

                    items.Add(item);
                }
            }
        }
    }

    public class TeaLeafItem
    {
        public String Name { get; set; }

        public String Address { get; set; }
    }
}
