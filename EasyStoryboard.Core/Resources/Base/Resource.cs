using EasyStoryboard.Core.Commons;
using EasyStoryboard.Core.Exceptions;
using EasyStoryboard.Core.Resources.Enums;
using System.IO;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class Resource
    {
        public string FileFullPath
        {
            set
            {
                if(value == null)
                {
                    throw new InvalidValueException("FileFullPath的值不能为null");
                }
                if (!File.Exists(value))
                {
                    throw new FileNotFoundException("", value);
                }
            }
            get
            {
                return Storyboard. + "\\" + FilePath;
            }
        }


        public string FilePath
        {
            set;get;
        }


        public Storyboard Storyboard;


        private ResourceType _resourceType;

        public Resource(ResourceType type)
        {
            _resourceType = type;
        }

        /// <summary>
        /// 生成storyboard脚本
        /// </summary>
        /// <param name="optimize">是否开启压缩sb的功能</param>
        /// <returns>storyboard脚本</returns>
        public abstract string ToString(bool optimize);


        public override string ToString()
        {
            return ToString(false);
        }
/*
        public void Load(string code) 
        {
            try
            {
                CommonUtil.CheckArgument(code);
                //LoadCode(code);
            }
            catch (System.Exception e)
            {
                throw new CodeArgumentException("Code: \"" + code + $"\", Message: {e.Message}");
            }
        }
*/
        
        protected string GetMaterialTypeCode(bool optimize)
        {
            return CommonUtil.GetEnumValue(_resourceType, optimize);
        }

    }
}
