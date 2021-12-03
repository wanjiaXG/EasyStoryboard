using EasyStoryboard.Core.Common;
using EasyStoryboard.Core.Exceptions;
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

        protected StaticResource(ResourceType type) : base(type) { }

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

        public StaticResource SetFilePath(string filePath)
        {
            FilePath = filePath;
            return this;
        }

        protected override void LoadCode(string code)
        {
            List<string> list = new List<string>();
            list = CommonUtil.Parse(code,",");

            string[] arr = code.Split(',');
            if (arr.Length >= 3)
            {
                ResourceType type = CommonUtil.CastValue<ResourceType>(arr[0]);

                if (type != ResourceType)
                {
                    throw new System.Exception("输入代码的资源类型与解析器的类型不匹配");
                }

                Offset = CommonUtil.CastValue<int>(arr[1]);
                FilePath = CommonUtil.CastValue<string>(arr[2]);
                TrimFilePath();
            }

            if (arr.Length >= 5)
            {
                X = CommonUtil.CastValue<int>(arr[3]);
                Y = CommonUtil.CastValue<int>(arr[4]);
            }
        }

        public override string GetCode(bool optimize)
        {
            return (X == 0 && Y == 0) ?
                $"{GetResourceCode(optimize)},{Offset},\"{FilePath}\"" :
                $"{GetResourceCode(optimize)},{Offset},\"{FilePath}\",{X},{Y}";
        }
        public override string ToString()
        {
            return GetCode(false);
        }
    }
}
