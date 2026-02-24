using SecsGem.Common.Dtos.Params.Validate.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsGem.Common.Dtos.Params.Validate
{
    public class ReportID : IDBase
    {
        public ReportID(uint _ID, string _Description, uint[] _LinkVID)
            : base(_ID, _Description)
        {
            LinkVID = _LinkVID;
        }

        public uint[] LinkVID { get; set; } = Array.Empty<uint>();
    }
}
