using SecsGem.Common.Const;
using SecsGem.Common.Dtos.Params.Validate;
using SecsGem.DataBase.Entities.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsGem.DataBase.Entities.Variable
{
    public class VIDEntity : BasicEntity
    {
        [Required(AllowEmptyStrings = false)]
        public override string ID { get; set; } = Guid.NewGuid().ToString();

        public uint Code { get; set; }

        public string Description { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;

        public string Type { get; set; }

        public string Value { get; set; }

    }


    public static class VIDExtend
    {
        public static VIDEntity GetVIDEntityFormVID(this VID vID)
        {
            VIDEntity vIDEntity = new VIDEntity();
            vIDEntity.Code = vID.ID;
            vIDEntity.Description = vID.Description;
            vIDEntity.Comment = vID.Comment;
            vIDEntity.Type = vID.DataType.ToString();
            vIDEntity.Value = vID.Value.ToString();
            return vIDEntity;
        }


        public static VID GetVIDFormVIDEntity(this VIDEntity vIDEntity)
        {
            Common.Const.DataType dataType = Enum.Parse<Common.Const.DataType>(vIDEntity.Type);
            VID vID = new VID(vIDEntity.Code, vIDEntity.Description, dataType);
            vID.Comment = vIDEntity.Comment;
            vID.SetValue(vIDEntity.Value);

            return vID;
        }

    }
}
