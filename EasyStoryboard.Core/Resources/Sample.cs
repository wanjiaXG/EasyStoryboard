using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;
using System;
using System.IO;
using System.Text;

namespace EasyStoryboard.Core
{
    public class Sample : Resource
    {
        public int Offset { set; get; }

        private int _volume = 100;

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
            ResourceType = ResourceType.Sample;
            ResoureLayerType = ResoureLayerType.SampleSound;
            LayerType = LayerType.Background;
        }

        //Sample,<time>,<layer_num>,"<filepath>",<volume>
        public override string GetCode(Options ops)
        {
            string filePath = ops.CopyFile.GetFilePath(ops.OuputDirectory, RelativePath, AbsoluteFilePath);

            StringBuilder sb = new StringBuilder();
            sb.Append(Commons.CommonUtil.GetEnumValue(ResourceType, ops.Optimize))
                .Append(',')
                .Append(Offset)
                .Append(',')
                .Append(Commons.CommonUtil.GetEnumValue(LayerType, ops.Optimize))
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
            
        }


    }
}
