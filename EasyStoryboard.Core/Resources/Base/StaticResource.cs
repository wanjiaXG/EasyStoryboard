using EasyStoryboard.Core.Commons;
using EasyStoryboard.Core.Exceptions;
using EasyStoryboard.Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static EasyStoryboard.Core.Commons.CommonUtil;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class StaticResource : GraphicsResource
    {
        public StaticResource(ResoureLayerType resoureLayerType,
            ResourceType resourceType) : base(resoureLayerType, resourceType) { }

        public StaticResource(string filePath, 
            ResoureLayerType resoureLayerType, 
            ResourceType resourceType) : base(filePath, resoureLayerType, resourceType) { }


        public StaticResource(string baseDirectory, 
            string relativePath, 
            ResoureLayerType resoureLayerType, 
            ResourceType resourceType) : base(baseDirectory, relativePath, resoureLayerType, resourceType) { }



        public int Offset { set; get; }

        protected void SetOffset(string value)
        {
            if (int.TryParse(value, out int offset))
            {
                Offset = offset;
            }
            else
            {
                throw new NotNumberException(value);
            }
        }

        public override string GetCode(Options ops)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(GetEnumValue(ResourceType, ops.Optimize))
                .Append(',')
                .Append(Offset)
                .Append(',')
                .Append('"')
                .Append(ops.CopyFile.GetFilePath(ops.OuputDirectory, RelativePath, AbsoluteFilePath))
                .Append('"');

            if(X != 0 || Y != 0)
            {
                sb.Append(',')
                    .Append(X)
                    .Append(',')
                    .Append(Y);
            }

            return sb.ToString();
        }

        public override void LoadCode(string baseDirectory, string code)
        {
            CheckStrings(baseDirectory, code);
            List<string> list = Split(code, ",");
            
            if(list.Count == 3 || list.Count == 5)
            {
                CheckResourcType(list[0]);
                SetOffset(list[1]);
                SetFileName(baseDirectory, list[2]);
                if (list.Count == 5)
                {
                    X = CastValue<int>(list[3]);
                    Y = CastValue<int>(list[4]);
                }
            }
            else
            {
                throw new ArgumentException("Code Format error.");
            }
        }
    }
}
