using EasyStoryboard.Core.Commons;
using EasyStoryboard.Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Resources.Base
{
    public abstract class StaticResource : GraphicsResource
    {

        public int Offset { set; get; }

        public StaticResource SetOffset(int offset)
        {
            Offset = offset;
            return this;
        }

        public StaticResource SetLocation(Location location)
        {
            Location = location;
            return this;
        }

        public void LoadCode(Storyboard sb, string code)
        {
            if (sb == null || string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Arguments can't be null");
            }

            List<string> list = CommonUtil.Split(code, ",");

            if (list.Count >= 3)
            {
                ResourceType type = CommonUtil.CastValue<ResourceType>(list[0]);

                if (type == ResourceType.Video || type == ResourceType.Background)
                {
                    Offset = CommonUtil.CastValue<int>(list[1]);
                    //FilePath = sb.BaseDirectory + "//" + CommonUtil.CastValue<string>(list[2]);
                }
                else
                {
                    throw new ArgumentException("ResourceType is not Background or Video");
                }
            }

            if (list.Count >= 5)
            {
                X = CommonUtil.CastValue<int>(list[3]);
                Y = CommonUtil.CastValue<int>(list[4]);
            }
        }




        /*        protected override void LoadCode(string code)
                {
                    List<string> list = new List<string>();
                    list = CommonUtil.Split(code,",");

                    //string[] arr = code.Split(',');
                    if (list.Count >= 3)
                    {
                        ResourceType type = CommonUtil.CastValue<ResourceType>(list[0]);

                        if (type != MaterialType)
                        {
                            throw new System.Exception("输入代码的资源类型与解析器的类型不匹配");
                        }

                        Offset = CommonUtil.CastValue<int>(list[1]);
                        FilePath = CommonUtil.CastValue<string>(list[2]);
                        //TrimFilePath();
                    }

                    if (list.Count >= 5)
                    {
                        X = CommonUtil.CastValue<int>(list[3]);
                        Y = CommonUtil.CastValue<int>(list[4]);
                    }
                }

                public override string GetCode(bool optimize)
                {
                    return (X == 0 && Y == 0) ?
                        $"{GetMaterialTypeCode(optimize)},{Offset},\"{FilePath}\"" :
                        $"{GetMaterialTypeCode(optimize)},{Offset},\"{FilePath}\",{X},{Y}";
                }*/
    }
}
