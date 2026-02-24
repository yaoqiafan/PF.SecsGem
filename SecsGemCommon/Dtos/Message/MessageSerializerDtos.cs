using SecsGem.Common.Const;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SecsGem.Common.Dtos.Message
{
    // SFCommand的数据库DTO
    public class SFCommandDbDto
    {
        public uint Stream { get; set; }
        public uint Function { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
        public string Key { get; set; } // 原JsonIgnore的属性
        public SecsGemMessageDbDto Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        
    }

    // SecsGemMessage的数据库DTO
    public class SecsGemMessageDbDto
    {
        public int Stream { get; set; }
        public string SystemBytes { get; set; } // Base64编码
        public int Function { get; set; }
        public int LinkNumber { get; set; }
        public bool WBit { get; set; }
        public SecsGemNodeMessageDbDto RootNode { get; set; }
        public string MessageId { get; set; }
        public int Depth { get; set; } // 消息深度，便于查询
    }

    // SecsGemNodeMessage的数据库DTO
    public class SecsGemNodeMessageDbDto
    {
        public DataType DataType { get; set; }
        public string Data { get; set; } // Base64编码
        public int Length { get; set; }
        public List<SecsGemNodeMessageDbDto> SubNode { get; set; }
        public bool IsVariableNode { get; set; }
        public uint VariableCode { get; set; }
        public string TypedValue { get; set; } // JSON字符串存储
        public string DataHex { get; set; } // 十六进制表示（可选，便于查看）

        // 节点路径（便于查询）
        public string NodePath { get; set; }
    }

    // JSON序列化配置
    public static class JsonOptions
    {
        public static readonly JsonSerializerOptions DatabaseOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false, // 存储时不需要缩进
            Converters = {
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
        },
            DefaultIgnoreCondition = JsonIgnoreCondition.Never // 不忽略任何属性
        };

        public static readonly JsonSerializerOptions TypedValueOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };
    }
}
