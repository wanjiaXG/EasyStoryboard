using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using static EasyStoryboard.Core.Commons.CommonUtil;

namespace EasyStoryboard.Core
{
    public class Sample : Resource
    {
        public int Offset { set; get; }

        private int _volume;

        public int Volume
        {
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new ArgumentException("Volume out of bounds, the valid range is 0-100");
                }
                _volume = value;
            }
            get
            {
                return _volume;
            }
        }

        public LayerType LayerType { set; get; }

        public Sample(string filePath) : base(filePath) { }

        public Sample(string baseDirectory, string relativePath) : base(baseDirectory, relativePath) { }

        public override void Init()
        {
            Volume = 100;
            ResourceType = ResourceType.Sample;
            ResoureLayerType = ResoureLayerType.SampleSound;
            LayerType = LayerType.Background;
        }

        //Sample,<time>,<layer_num>,"<filepath>",<volume>
        public override string GetCode(Options ops)
        {
            string filePath = ops.CopyFile.GetFilePath(ops.OuputDirectory, RelativePath, AbsoluteFilePath);

            StringBuilder sb = new StringBuilder();
            sb.Append(GetEnumValue(ResourceType, ops.Optimize))
                .Append(',')
                .Append(Offset)
                .Append(',')
                .Append(GetEnumValue(LayerType, ops.Optimize))
                .Append(',')
                .Append('"')
                .Append(filePath)
                .Append('"')
                .Append(',')
                .Append(Volume);

            return sb.ToString();
        }

        public override void LoadCode(Storyboard sb, string code)
        {
            List<string> list = Split(code, ",");
            if(list.Count != 5)
            {
                throw new ArgumentException("Code Format error.");
            }
            else
            {
                if(Enum.TryParse(list[0], out ResourceType type) && type.Equals(ResourceType.Sample))
                {
                    if(int.TryParse(list[1], out int offset))
                    {
                        Offset = offset;
                    }
                    else
                    {
                        throw new ArgumentException("Offset is not number.");
                    }



                }
                else
                {
                    throw new ArgumentException("ResourceType is not Sample.");
                }
            }
        }

    }
}
