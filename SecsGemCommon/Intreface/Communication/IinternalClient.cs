using PF.ICommunication;
using SecsGemCommon.Dtos.Message;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsGem.Common.Intreface.Communication
{
   
        /// <summary>
        /// SECS/GEM 内部客户端接口
        /// </summary>
        public interface IinternalClient : IDisposable
        {
            /// <summary>
            /// SECS/GEM 连接状态
            /// </summary>
            bool SecsGemStatus { get; }

            /// <summary>
            /// 回复消息缓存
            /// </summary>
            ConcurrentDictionary<string, SecsGemMessage> ReplyMessageInfo { get; }

            /// <summary>
            /// 初始化客户端
            /// </summary>
            /// <returns>初始化结果</returns>
            Task<bool> InitializationClient();

            /// <summary>
            /// 启动客户端
            /// </summary>
            /// <returns>启动结果</returns>
            Task<bool> StartClient();

            /// <summary>
            /// 关闭客户端连接
            /// </summary>
            Task Close();

            /// <summary>
            /// 发送SECS/GEM消息
            /// </summary>
            /// <param name="msg">消息对象</param>
            Task SendMessage(SecsGemMessage msg);

           
            /// <summary>
            /// 等待回复消息
            /// </summary>
            /// <param name="systemBytesHex">SystemBytes十六进制字符串</param>
            /// <param name="timeoutMs">超时时间（毫秒）</param>
            /// <returns>回复消息</returns>
            Task<SecsGemMessage> WaitForReplyAsync(string systemBytesHex, int timeoutMs = 5000);

            /// <summary>
            /// 记录SECS/GEM交互日志
            /// </summary>
            /// <param name="strData">日志内容</param>
            void WriteSecsGemLog(string strData);


        event EventHandler<SecsMessageReceivedEventArgs> MessageReceived;
    }


  
}
