using SecsGem.Common.Dtos.Params.Validate.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataType = SecsGem.Common.Const.DataType;

namespace SecsGem.Common.Dtos.Params.Validate
{
    public class VID : IDBase
    {
        public VID(uint _ID, string _Description, DataType dataType)
            : base(_ID, _Description)
        {
            DataType = dataType;
        }

        public DataType DataType { get; set; }
        public object? Value { get; set; }

        public T? GetValue<T>()
        {
            if (Value == null) return default;
            try
            {
                return (T)Convert.ChangeType(Value, typeof(T));
            }
            catch
            {
                return default;
            }
        }


        public bool SetValue(object value)
        {
            Type type = default;
            try
            {
                switch (DataType)
                {
                    case DataType.LIST:
                        type = typeof(Array);
                        break;
                    case DataType.Binary:
                        type = typeof(BitArray);
                        break;
                    case DataType.Boolean:
                        type = typeof(bool);
                        break;
                    case DataType.ASCII:
                        type = typeof(string);
                        break;
                    case DataType.JIS8:
                        type = typeof(string);
                        break;
                    case DataType.CHARACTER_2:
                        type = typeof(string);
                        break;
                    case DataType.I8:
                        type = typeof(Int128);
                        break;
                    case DataType.I1:
                        type = typeof(short);
                        break;
                    case DataType.I2:
                        type = typeof(int);
                        break;
                    case DataType.I4:
                        type = typeof(long);
                        break;
                    case DataType.F8:
                        type = typeof(double);
                        break;
                    case DataType.F4:
                        type = typeof(float);
                        break;
                    case DataType.U8:
                        type = typeof(UInt128);
                        break;
                    case DataType.U1:
                        type = typeof(ushort);
                        break;
                    case DataType.U2:
                        type = typeof(uint);
                        break;
                    case DataType.U4:
                        type = typeof(ulong);
                        break;
                    default:
                        break;
                }
                Value = Convert.ChangeType(value, type);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
