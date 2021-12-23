using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Text;

using static EasyStoryboard.Core.Commons.CommonUtil;

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

        public LayerType LayerType { set; get; } = LayerType.Background;

        public Sample() : base(ResoureLayerType.SampleSound, ResourceType.Sample) { }

        public Sample(string filePath) : base(filePath, ResoureLayerType.SampleSound, ResourceType.Sample) { }

        public Sample(string baseDirectory, string relativePath) : base(baseDirectory, relativePath, ResoureLayerType.SampleSound, ResourceType.Sample) { }

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

        protected void SetOffset(string value)
        {
            if (int.TryParse(value, out int offset))
            {
                Offset = offset;
            }
            else
            {
                throw new ArgumentException("Offset is not number.");
            }
        }
        
        protected void SetLayerType(string value)
        {
            if (Enum.TryParse(value, out LayerType layerType))
            {
                LayerType = layerType;
            }
            else
            {
                throw new ArgumentException("LayerType is unknow type.");
            }
        }
        
        protected void SetVolume(string value)
        {
            if (int.TryParse(value, out int vol))
            {
                Volume = vol;
            }
            else
            {
                throw new ArgumentException("Volume is not number.");
            }
        }

        public override void LoadCode(string baseDirectory, string code)
        {
            CheckStrings(baseDirectory, code);
            List<string> list = Split(code, ",");
            if(list.Count != 5)
            {
                throw new ArgumentException("Code Format error.");
            }
            else
            {
                CheckResourcType(list[0]);
                SetOffset(list[1]);
                SetLayerType(list[2]);
                SetFileName(baseDirectory, list[3]);
                SetVolume(list[4]);                
            }
        }

    }
}
