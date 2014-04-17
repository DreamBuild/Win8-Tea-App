using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaApp.Common;
using TeaApp.Services;

namespace TeaApp.DataModel
{
    public class ChatRoomModel : BindableBase
    {
        public ChatRoomModel()
        {
            ChatRoomService service = new ChatRoomService();
            this.SendHistory = service.GetLocalAddress();
            SendCommand = new RelayCommand(new Action(Send));
        }

        private void Send()
        {

        }

        private String localAddress;

        public String LocalAddress 
        {
            get { return this.localAddress; }
            set { SetProperty(ref this.localAddress,value);} 
        }

        private String targetAddress;
        public String TargetAddress 
        {
            get { return this.targetAddress; }
            set { SetProperty(ref this.targetAddress, value); } 
        }

        private String content;
        public String SendHistory
        { 
            get { return this.content; } 
            set { SetProperty(ref this.content, value); } 
        }

        private String input;
        public String SendContent
        {
            get { return input; }
            set 
            { 
                if(!String.IsNullOrEmpty(value))
                { 
                    SetProperty(ref this.input,value);
                    this.SendCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public RelayCommand SendCommand { get; set; }
    }
}
