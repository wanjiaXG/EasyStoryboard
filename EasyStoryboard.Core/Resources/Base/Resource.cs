using EasyStoryboard.Core.Common;
using EasyStoryboard.Core.Resources.Enum;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class Resource
    {
        public string FilePath { set; get; }

        public ResourceType ResourceType { private set; get; }

        public Resource(ResourceType type)
        {
            ResourceType = type;
        }

        public abstract string GetCode(bool optimize);

        protected string GetResourceType(bool optimize)
        {
            return CommonUtil.GetEnumValue(ResourceType, optimize);
        }

    }
}
