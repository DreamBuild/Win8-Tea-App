using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaApp.Common;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace TeaApp.DataModel
{
    public class TeaTopicDataSource
    {
        public static List<TeaTopicItem> GetTopicItems()
        {
            List<TeaTopicItem> items = new List<TeaTopicItem>();

            items.Add(new TeaTopicItem("追茶", "Images/homepage/main1.jpg", "茶者，南方之嘉木也。一尺、二尺乃至数十尺。其树如瓜芦，叶如栀子，花如白蔷薇，实如栟榈，蒂如丁香，根如胡桃。"));
            items.Add(new TeaTopicItem("说茶", "Images/homepage/main2.jpg", "茶有千万状，卤莽而言，如胡人靴者，蹙缩然；犎牛臆者，廉襜然；浮云出山者，轮然；轻飙拂水也。"));
            items.Add(new TeaTopicItem("品茶", "Images/homepage/main3.jpg", "华之薄者曰沫，厚者曰饽，轻细者曰花，花，如枣花漂漂然于环池之上；又如回潭曲渚青萍之始生；又如晴天爽朗，有浮云鳞然。"));
            items.Add(new TeaTopicItem("饮茶", "Images/homepage/main4.jpg", "茶之为用，味至寒，为饮最宜。精行俭德之人，若热渴、凝闷、脑疼、目涩、四肢烦、百节不舒，聊四五啜，与醍醐、甘露抗衡也。"));
            //items.Add(new TeaTopicItem("聊天室", "Images/homepage/main1.jpg", "聊天功能"));
            return items;
        }
    }
    public class TeaTopicItem : BindableBase
    {
        private String title;
        private String imagePath;
        private Uri basePath = new Uri("ms-appx:///");

        public TeaTopicItem(String title, String imagePath,String description)
        {
            this.title = title;
            this.imagePath = imagePath;
            this.Description = description;
        }

        public String Title 
        { 
            get { return this.title; }
        }

        public ImageSource ImagePath { get { return new BitmapImage(new Uri( this.basePath,imagePath)); } }

        public String Description { get; set; }

    }
}
