using EasyStoryboard.Core.Commons;
using EasyStoryboard.Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class StaticResource : GraphicsResource
    {
        public int Offset { set; get; }

        internal StaticResource(ResourceType type) : base(type) { }

        protected StaticResource(string filePath, ResourceType type) : this(type)
        {
            FilePath = filePath;
        }

        protected StaticResource(string filePath, SBLocation location, ResourceType type) : this(filePath, type)
        {
            Location = location;
        }

        public StaticResource SetOffset(int offset)
        {
            Offset = offset;
            return this;
        }

        public StaticResource SetLocation(SBLocation location)
        {
            Location = location;
            return this;
        }

/*        protected override void LoadCode(string code)
        {
            List<string> list = new List<string>();
            list = CommonUtil.Split(code,",");

            //string[] arr = code.Split(',');
            if (list.Count >= 3)
            {
                ResourceType type = CommonUtil.CastValue<ResourceType>(list[0]);

                if (type != MaterialType)
                {
                    throw new System.Exception("输入代码的资源类型与解析器的类型不匹配");
                }

                Offset = CommonUtil.CastValue<int>(list[1]);
                FilePath = CommonUtil.CastValue<string>(list[2]);
                //TrimFilePath();
            }

            if (list.Count >= 5)
            {
                X = CommonUtil.CastValue<int>(list[3]);
                Y = CommonUtil.CastValue<int>(list[4]);
            }
        }

        public override string GetCode(bool optimize)
        {
            return (X == 0 && Y == 0) ?
                $"{GetMaterialTypeCode(optimize)},{Offset},\"{FilePath}\"" :
                $"{GetMaterialTypeCode(optimize)},{Offset},\"{FilePath}\",{X},{Y}";
        }*/
    }
}
