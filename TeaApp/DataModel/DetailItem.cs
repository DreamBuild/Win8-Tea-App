using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace TeaApp.DataModel
{
    public class DetailItem
    {
        private String imagePath;
        private String basePath = "ms-appx:///";

        public ImageSource ImagePath 
        { 
            get 
            { 
                return new BitmapImage(new Uri(new Uri(basePath), imagePath)); 
            } 
        }

        public void SetImagePath(String path)
        {
            this.imagePath = path;
        }

        public String Name { get; set; }

        public String Content { get; set; }
    }
}
