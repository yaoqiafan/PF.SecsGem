using SecsGem.Common.Intreface.Command;
using SecsGem.Common.Intreface.Communication;
using SecsGem.Common.Intreface.Params;
using SecsGem.Common.Tools;
using SecsGemCommon.Dtos.Message;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsGem.Common.Intreface
{
    public interface ISecsGemManger : IDisposable
    {
        Task<bool> InitializeAsync();
        Task<bool> ConnectAsync();
        Task DisconnectAsync();
        Task SendMessageAsync(SecsGemMessage message);
        Task<bool> WaitSendMessageAsync(SecsGemMessage message, string systemBytesHex);

        bool IsConnected { get; }
       
        IParams ParamsManager { get; }
        ICommandManager CommandManager { get; }
        IinternalClient SecsGemClient { get; }
        MessageUpdater MessageUpdater { get; }


        event EventHandler<SecsMessageReceivedEventArgs> MessageReceived;
       
    }

    public class ConnectionStateChangedEventArgs : EventArgs
    {
        public bool OldState { get; set; }
        public bool NewState { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class SecsMessageReceivedEventArgs : EventArgs
    {
        public SecsGemMessage Message { get; set; }
        public DateTime Timestamp { get; set; }


    }

}
