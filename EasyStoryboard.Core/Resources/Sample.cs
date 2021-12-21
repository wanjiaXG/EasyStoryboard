using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;
using System;
using System.IO;

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
            ResourceType = ResourceType.Sample;
            ResoureLayerType = ResoureLayerType.SampleSound;
            LayerType = LayerType.Background;
        }

        //Sample,<time>,<layer_num>,"<filepath>",<volume>
        public override string GetCode(SaveOptions ops)
        {
            if (!File.Exists(AbsoluteFilePath)) throw new FileNotFoundException($"File '{AbsoluteFilePath}' not found.");


            return "";
        }

        public override void LoadCode(Storyboard sb, string code)
        {
            
        }


    }
}
