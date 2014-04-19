using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;

namespace TeaApp.DataModel
{
    public  class JsonArrayReader
    {
        /// <summary>
        /// 从Data文件夹下读取json数据
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static async Task<JsonArray> ReadArrayFromFile(String filename)
        {
            Uri dataUri = new Uri("ms-appx:///Data/" + filename);

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);

            JsonArray jsonArray = JsonArray.Parse(jsonText);

            return jsonArray;
        }

        public static List<DetailItem> GetDetailItemsFromJsonArray(JsonArray jsonArray)
        {
            JsonObject obj;
            DetailItem detailItem;
            List<DetailItem> details = new List<DetailItem>();

            for (int j = 0; j < jsonArray.Count; j++)
            {
                obj = jsonArray[j].GetObject();
                detailItem = new DetailItem();

                detailItem.Name = obj["name"].GetString();
                detailItem.Content = obj["content"].GetString();

                details.Add(detailItem);
            }
            return details;
        }
    }
}
