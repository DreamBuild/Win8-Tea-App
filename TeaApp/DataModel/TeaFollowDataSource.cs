using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace TeaApp.DataModel
{
    public class TeaFollowDataSource
    {
        public async Task<List<FollowTeaItem>> GetFollowTeaItems()
        {
            Uri dataUri = new Uri("ms-appx:///Data/fllow_tea_items.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);

            JsonArray jsonArray = JsonArray.Parse(jsonText);

            List<FollowTeaItem> items = new List<FollowTeaItem>();

            JsonObject obj;
            FollowTeaItem item;
            DetailItem detailItem;
            JsonArray detailArray;
            List<DetailItem> details;

            for (int i = 0; i < jsonArray.Count; i++)
            {
                obj = jsonArray[i].GetObject();

                item = new FollowTeaItem();
                item.Title = obj["title"].GetString();
                item.SetImagePath(obj["image_path"].GetString());
                item.TitleIndex = i % 2;

                detailArray = obj["detail"].GetArray();
                details = new List<DetailItem>();

                for (int j = 0; j < detailArray.Count; j++)
                {
                    obj = detailArray[j].GetObject();
                    detailItem = new DetailItem();

                    detailItem.Name = obj["name"].GetString();
                    detailItem.Content = obj["content"].GetString();

                    details.Add(detailItem);
                }
                item.Details = details;
                items.Add(item);
            }

            return items;
        }
    }

    public class FollowTeaItem
    {
        private String imagePath;
        private Uri basePath = new Uri("ms-appx:///");

        public String Title { get; set; }

        public ImageSource ImagePath 
        { 
            get 
            { 
                return new BitmapImage(new Uri(basePath, imagePath)); 
            } 
        }

        public int TitleIndex 
        { 
            get; set; }

        public int ImageIndex 
        {
            get { return 1 - this.TitleIndex; }
        }

        public void SetImagePath(String path)
        {
            this.imagePath = path;
        }

        public List<DetailItem> Details { get; set; }
    }
}
