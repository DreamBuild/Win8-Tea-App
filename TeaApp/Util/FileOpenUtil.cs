using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Markup;

namespace TeaApp.Util
{
    public static class FileOpenUtil
    {
        public static async Task<StorageFile> OpenRtfFileAsync(String filename)
        {
            Uri dataUri = new Uri("ms-appx:///Data/" + filename);

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
           
            return file;
        }
    }
}
