using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsGemCommon.Dtos.Message
{
    public class SecsGemMessage
    {
        /// <summary>
        /// Stream号（S）
        /// </summary>
        public int Stream { get; set; }


        /// <summary>
        /// 系统字节（System Bytes）
        /// </summary>
        public List<byte> SystemBytes { get; set; } = new List<byte>();

        /// <summary>
        /// Function号（F）
        /// </summary>
        public int Function { get; set; }

        /// <summary>
        /// S0F0标识的Link号
        /// </summary>
        public int LinkNumber { get; set; } = 0;

        /// <summary>
        /// WBit标识（是否需要回复）
        /// </summary>
        public bool WBit { get; set; }

        /// <summary>
        /// 消息根节点
        /// </summary>
        public SecsGemNodeMessage RootNode { get; set; } = new SecsGemNodeMessage();

        /// <summary>
        /// 消息唯一标识
        /// </summary>
        public string MessageId { get; set; } = Guid.NewGuid().ToString();
    }
}
