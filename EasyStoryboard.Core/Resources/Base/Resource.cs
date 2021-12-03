using EasyStoryboard.Core.Common;
using EasyStoryboard.Core.Exceptions;
using EasyStoryboard.Core.Resources.Enums;

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

        public void Load(string code) 
        {
            try
            {
                CommonUtil.CkeckArgument(code);
                LoadCode(code);
            }
            catch (System.Exception e)
            {
                throw new CodeArgumentException("Code: " + code + $"{e.Message}");
            }
        }

        protected abstract void LoadCode(string code);

        protected string GetResourceCode(bool optimize)
        {
            return CommonUtil.GetEnumValue(ResourceType, optimize);
        }

        protected void TrimFilePath()
        {
            if (FilePath != null && FilePath.StartsWith("\"") && FilePath.EndsWith("\""))
            {
                FilePath = FilePath.Substring(1, FilePath.Length - 2);
            }
        }



    }
}
