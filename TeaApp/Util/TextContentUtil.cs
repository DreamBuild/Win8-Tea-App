using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace TeaApp.Util
{
    public class TextContentUtil
    {
        public async Task<List<Paragraph>> Resolver(String filename)
        {
            List<Paragraph> ps = new List<Paragraph>();

            Uri dataUri = new Uri("ms-appx:///Data/" + filename);

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);

            XmlDocument doc = await XmlDocument.LoadFromFileAsync(file);

            XmlElement root = doc.DocumentElement;
            Paragraph p = null;
            String content = null;

            XmlElement tmp;
            for (int i = 0; i < root.ChildNodes.Length; i++)
            {

                if (root.ChildNodes[i].NodeType == NodeType.ElementNode)
                {
                    tmp = root.ChildNodes[i] as XmlElement;
                    content = tmp.GetXml();
                    p = XamlReader.Load(content.Trim()) as Paragraph;
                    if(p != null)
                    { 
                        ps.Add(p);
                    }
                }
            }
            
            return ps;
        }

        public async Task<IRandomAccessStream> GetRandomFile(String path)
        {
            Uri dataUri = new Uri("ms-appx:///" + path);

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);

            IRandomAccessStream randAccStream =
            await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

            return randAccStream;
        }
    }
}
