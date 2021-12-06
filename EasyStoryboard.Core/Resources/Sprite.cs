using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;
using System.Text;

namespace EasyStoryboard.Core
{
    public class Sprite : DynamicResource
    {
        public Sprite() : base(ResourceType.Sprite)
        {
        }

        //Sprite,Pass,Centre,"Text\Play2-HaveFunH.png",320,240
        public override string GetCode(bool optimize)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetMaterialTypeCode(optimize));
            sb.Append(',');
            sb.Append(GetLayerTypeCode(optimize));
            sb.Append(',');
            sb.Append(GetOriginTypeCode(optimize));
            sb.Append(',');
            sb.Append('"');
            sb.Append(FilePath);
            sb.Append('"');


            throw new System.NotImplementedException();
        }

        protected override void LoadCode(string code)
        {
            throw new System.NotImplementedException();
        }
    }
}
