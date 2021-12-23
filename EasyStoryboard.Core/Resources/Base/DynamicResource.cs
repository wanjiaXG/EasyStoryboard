using EasyStoryboard.Core.Commands.Base;
using EasyStoryboard.Core.Commons;
using EasyStoryboard.Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class DynamicResource : GraphicsResource
    {
        public DynamicResource(ResoureLayerType resoureLayerType,
            ResourceType resourceType) : base(resoureLayerType, resourceType) { }

        public DynamicResource(string filePath, ResoureLayerType resoureLayerType, ResourceType resourceType) : base(filePath, resoureLayerType, resourceType) { }


        public DynamicResource(string baseDirectory, string relativePath, ResoureLayerType resoureLayerType, ResourceType resourceType) : base(baseDirectory, relativePath, resoureLayerType, resourceType) { }


        public LayerType LayerType { set; get; }

        public OriginType OriginType { set; get; }

        List<BaseCommand> Commands { get; } = new List<BaseCommand>();
        
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

        protected void SetOriginType(string value)
        {
            if (Enum.TryParse(value, out OriginType originType))
            {
                OriginType = originType;
            }
            else
            {
                throw new ArgumentException("OriginType is unknow type.");
            }
        }

    }
}
