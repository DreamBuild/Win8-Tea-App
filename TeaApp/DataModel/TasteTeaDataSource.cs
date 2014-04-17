using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.UI.Xaml.Media;

namespace TeaApp.DataModel
{
    public class TasteTeaDataSource
    {
        public async Task<List<DetailItem>> GetTasteTeaItems()
        {
            JsonArray jsonArray =await JsonArrayReader.ReadArrayFromFile("taste_tea.json");
            List<DetailItem> items = JsonArrayReader.GetDetailItemsFromJsonArray(jsonArray);
            return items;
        }

        //public async Task<List<TasteTeaItemModel>> GetItems()
        //{

        //}
    }

    public class TasteTeaItemModel
    {
        public String Title { get; set; }

        public List<SeasonItem> SeasonItems { get; set; }
    }

    public class SeasonItem
    {
        public String ItemContent { get; set; }

        public ImageSource ItemImage { get; set; }
    }
}
