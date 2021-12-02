using EasyStoryboard.Core.Resource.Enum;

namespace EasyStoryboard.Core.Resource.Base
{
    public abstract class BaseResource : IResource
    {
        public ResourceType ResourceType { private set; get; }

        public BaseResource(ResourceType type)
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
