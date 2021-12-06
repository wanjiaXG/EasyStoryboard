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
        public LayerType LayerType { set; get; }

        public OriginType OriginType { set; get; }

        List<Command> Commands { get; } = new List<Command>();

        public DynamicResource(ResourceType type) : base(type)
        {
        }

        protected string GetLayerTypeCode(bool optimize)
        {
            return CommonUtil.GetEnumValue(LayerType, optimize);
        }

        protected string GetOriginTypeCode(bool optimize)
        {
            return CommonUtil.GetEnumValue(OriginType, optimize);
        }
    }
}
