using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsGem.Common.Const
{
    public static  class SecsGemErrorCode
    {
        // 错误代码映射
        private static  readonly Dictionary<byte, string> Errors = new Dictionary<byte, string>()
        {
            {0x00, "Abort Transaction"},
            {0x01, "Unrecognized Device ID"},
            {0x03, "Unrecognized Stream Type"},
            {0x05, "Unrecognized Function Type"},
            {0x07, "Illegal Data"},
            {0x09, "Transaction Timer Timeout"},
        };

    }
}
