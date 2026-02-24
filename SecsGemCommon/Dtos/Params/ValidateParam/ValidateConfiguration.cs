using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SecsGem.Common.Const;
using SecsGem.Common.Intreface.DataBase;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SecsGem.Common.Dtos.Params.Validate
{
    public class ValidateConfiguration
    {
        public static readonly string filePath = Path.Combine(PFCommonParame.PFFileParame.ConfigPath, "SecsGemInformationConfig.xlsx");
        private static readonly object _lock = new object();
        
        public ConcurrentDictionary<string, CEID> CEIDS { get; set; } = new();
        public ConcurrentDictionary<string, ReportID> ReportIDS { get; set; } = new();
        public ConcurrentDictionary<string, VID> VIDS { get; set; } = new();

        public ConcurrentDictionary<string, CommandID> CommandIDS { get; set; } = new();


        public CEID? GetCEID(string description)
        {
            return CEIDS.TryGetValue(description, out var ceid) ? ceid : null;
        }

        public ReportID? GetReportID(string description)
        {
            return ReportIDS.TryGetValue(description, out var report) ? report : null;
        }

        public VID? GetVID(string description)
        {
            return VIDS.TryGetValue(description, out var vid) ? vid : null;
        }

        public List<VID>? GetVIDsWithCEID(string CEIDdescription)
        {
            List<VID>? result = new List<VID>();
            CEID? cEID = GetCEID(CEIDdescription);
            if (cEID != null)
            {
                for (int j = 0; j < cEID.LinkReportID.Length; j++)
                {
                    ReportID? reportID = GetReportID(cEID.LinkReportID[j]);
                    if (reportID != null)
                    {
                        for (int i = 0; i < reportID.LinkVID.Length; i++)
                        {
                            VID? vID = GetVID(reportID.LinkVID[i]);
                            if (vID != null)
                            {
                                result.Add(vID);
                            }
                        }
                    }
                }
            }
            return result;
        }


        public CommandID? GetCommandID(string description)
        {
            return CommandIDS.TryGetValue(description, out var cmd) ? cmd : null;
        }


        public CommandID? GetCommandIDByRCMD(string RCMD)
        {
            return CommandIDS.Values.FirstOrDefault(cmd => cmd.RCMD == RCMD);
        }

        public bool SetVIDValue(string description, object value)
        {
            if (VIDS.TryGetValue(description, out var vid))
            {
                return vid.SetValue(value);
            }
            return false;
        }


        // 基于ID的查找方法
        public CEID? GetCEID(uint code)
        {
            return CEIDS.Values.FirstOrDefault(ceid => ceid.ID == code);
        }

        public ReportID? GetReportID(uint code)
        {
            return ReportIDS.Values.FirstOrDefault(report => report.ID == code);
        }

        public VID? GetVID(uint code)
        {
            return VIDS.Values.FirstOrDefault(vid => vid.ID == code);
        }
        public List<VID>? GetVIDsWithCEID(uint CEIDcode)
        {
            List<VID>? result = new List<VID>();
            CEID? cEID = GetCEID(CEIDcode);
            if (cEID != null)
            {
                for (int j = 0; j < cEID.LinkReportID.Length; j++)
                {
                    ReportID? reportID = GetReportID(cEID.LinkReportID[j]);
                    if (reportID != null)
                    {
                        for (int i = 0; i < reportID.LinkVID.Length; i++)
                        {
                            VID? vID = GetVID(reportID.LinkVID[i]);
                            if (vID != null)
                            {
                                result.Add(vID);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public CommandID? GetCommand(uint code)
        {
            return CommandIDS.Values.FirstOrDefault(cmd => cmd.ID == code);
        }

        public bool SetVIDValue(uint code, object value)
        {
            var vid = GetVID(code);

            if (vid != null)
            {
                return vid.SetValue(value);
            }
            return false;
        }


        public IEnumerable<CEID> GetCEIDs(IEnumerable<uint> codes)
        {
            return CEIDS.Values.Where(ceid => codes.Contains(ceid.ID));
        }

        public IEnumerable<ReportID> GetReportIDs(IEnumerable<uint> codes)
        {
            return ReportIDS.Values.Where(report => codes.Contains(report.ID));
        }

        public IEnumerable<VID> GetVIDs(IEnumerable<uint> codes)
        {
            return VIDS.Values.Where(vid => codes.Contains(vid.ID));
        }


        public IEnumerable<CommandID> GetCommands(IEnumerable<uint> codes)
        {
            return CommandIDS.Values.Where(cmd => codes.Contains(cmd.ID));
        }

        public void AddCEID(string description, CEID ceid)
        {
            CEIDS[description] = ceid;
        }

        public void AddReportID(string description, ReportID report)
        {
            ReportIDS[description] = report;
        }

        public void AddVID(string description, VID vid)
        {
            VIDS[description] = vid;
        }


        public void AddCommandID(string description, CommandID cmd)
        {
            CommandIDS[description] = cmd;
        }

        // 获取关联的ReportID
        public IEnumerable<ReportID> GetLinkedReports(CEID ceid)
        {
            return ceid.LinkReportID
                .Select(reportId => ReportIDS.Values.FirstOrDefault(r => r.ID == reportId))
                .Where(report => report != null)!;
        }

        // 获取关联的VID
        public IEnumerable<VID> GetLinkedVIDs(ReportID report)
        {
            return report.LinkVID
                .Select(vidId => VIDS.Values.FirstOrDefault(v => v.ID == vidId))
                .Where(vid => vid != null)!;
        }

        public IEnumerable<VID> GetLinkedVIDs(CommandID command)
        {
            return command.LinkVID.Select(vidId => VIDS.Values.FirstOrDefault(v => v.ID == vidId))
                .Where(vid => vid != null)!;
        }

        // 批量更新VID值
        public void UpdateMultipleVIDs(Dictionary<string, object> updates)
        {
            foreach (var (key, value) in updates)
            {
                if (VIDS.TryGetValue(key, out var vid))
                {
                    vid.SetValue(value);
                }
            }
        }

        public void UpdateMultipleVIDs(Dictionary<uint, object> updates)
        {
            foreach (var (key, value) in updates)
            {
                var vid = GetVID(key);
                vid?.SetValue(value);
            }
        }

        // 验证方法
        public bool Validate()
        {
            bool allReportsExist = CEIDS.Values.All(ceid =>
                ceid.LinkReportID.All(reportId =>
                    ReportIDS.Values.Any(r => r.ID == reportId)));

            bool allVIDsExist = ReportIDS.Values.All(report =>
                report.LinkVID.All(vidId =>
                    VIDS.Values.Any(v => v.ID == vidId)));

            bool allCommandVIDsExist = CommandIDS.Values.All(cmd =>
                cmd.LinkVID.All(vidId =>
                    VIDS.Values.Any(v => v.ID == vidId)));

            return allReportsExist && allVIDsExist && allCommandVIDsExist;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

       
    }
}
