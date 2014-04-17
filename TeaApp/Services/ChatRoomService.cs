using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Connectivity;

namespace TeaApp.Services
{
    public class ChatRoomService
    {
        public String GetLocalAddress()
        {
            StringBuilder sb = new StringBuilder();

            IReadOnlyList<HostName> names = NetworkInformation.GetHostNames();
            foreach (var item in names)
            {
                sb.AppendLine(item.CanonicalName);
            }

            return sb.ToString();
        }
    }
}
