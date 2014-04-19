using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace TeaApp.DataModel
{
    public class TeaPlaceDataSource
    {
        private static Dictionary<String, String> Contents = new Dictionary<string, string>();

        public async Task<String> GetProvinceContent(String province)
        {
            if (Contents.Count == 0)
            {
                await GetProvinces();
            }
            
            return Contents[province];
        }

        private async Task GetProvinces()
        {
            JsonArray jsonArray = await JsonArrayReader.ReadArrayFromFile("TalkTea/provinces.json");

            String name, content;
            JsonObject obj;

            for (int i = 0; i < jsonArray.Count; i++)
            {
                obj = jsonArray[i].GetObject();

                if(obj != null)
                {
                    name = obj["name"].GetString().Substring(0,2);
                    content = obj["content"].GetString();

                    Contents.Add(name, content);
                }
            }
        }
    }
}
