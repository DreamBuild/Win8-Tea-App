using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaApp.Common;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Storage;

namespace TeaApp.DataModel
{
    public class TeaDrinkDataSource
    {
        public TeaDrinkDataSource()
        {
            this.Teas = new List<DetailItem>();
        }

        public async Task<List<DetailItem>> GetTeaItemsSaync()
        {
            await GetTeasAsync();

            return this.Teas;
        }

        private async Task GetTeasAsync()
        {
            if (Teas.Count != 0)
                return;

            Uri dataUri = new Uri("ms-appx:///Data/teas.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);

            JsonArray jsonArray = JsonArray.Parse(jsonText);

            JsonObject obj = null;
            DetailItem tea = null;
            foreach (var item in jsonArray)
            {
                tea = new DetailItem();
                obj = item.GetObject();
                tea.Name = obj["name"].GetString();
                tea.Content = obj["content"].GetString();
                tea.SetImagePath(obj["image"].GetString());

                this.Teas.Add(tea);
            }
        }

        public List<DetailItem> Teas { get; set; }
    } 
    
    public class Tea : BindableBase
    {
        private String name;
        private String content;

        public String Name 
        {
            get { return this.name; } 
            set
            {
                this.SetProperty(ref this.name, value);
            } 
        }

        public String Content
        {
            get { return this.content; }
            set
            {
                this.SetProperty(ref this.content, value);
            }
        }
    }
}
