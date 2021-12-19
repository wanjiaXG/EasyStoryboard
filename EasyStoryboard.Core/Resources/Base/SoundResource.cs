using EasyStoryboard.Core.Commons;
using EasyStoryboard.Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class SoundResource : Resource
    {
        public int Offset { set; get; }

        private int _volume;
        public int Volume
        {
            set
            {
                if(value > 100 || value < 0)
                {
                    throw new ArgumentException("Volume out of bounds, the valid range is 0-100");
                }
                Volume = value;
            }
            get
            {
                return _volume;
            }
        }

        public LayerType LayerType { set; get; }

        internal SoundResource(ResourceType type, string filePath) : base(type, filePath) { }

    }
}
