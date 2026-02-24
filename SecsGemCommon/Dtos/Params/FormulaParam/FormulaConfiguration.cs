using SecsGem.Common.Dtos.Command;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SecsGem.Common.Dtos.Params.FormulaParam
{
    public class FormulaConfiguration
    {

        public ConcurrentDictionary<string, SFCommand> IncentiveCommandDictionary { get; set; }=new ConcurrentDictionary<string, SFCommand>();

        public ConcurrentDictionary<string, SFCommand> ResponseCommandDictionary { get; set; } = new ConcurrentDictionary<string, SFCommand>();

    }
}
