using SecsGem.Common.Dtos.Params.Validate.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsGem.Common.Dtos.Params.Validate
{
    public class CommandID : IDBase
    {
        public CommandID(uint _ID, string _Description, uint[] _LinkVID, string RCMD,string _Key) : base(_ID, _Description)
        {
            this.LinkVID = _LinkVID;
            this.RCMD = RCMD;
            this.Key = _Key;
        }

        public uint[] LinkVID { get; set; } = Array.Empty<uint>();

        public string RCMD { get; set; } = string.Empty;
       
        public string Key { get; set; } = string.Empty;
    }
}
