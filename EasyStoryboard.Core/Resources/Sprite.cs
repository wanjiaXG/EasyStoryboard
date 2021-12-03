using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;

namespace EasyStoryboard.Core
{
    public class Sprite : DynamicResource
    {
        public Sprite(ResourceType type) : base(ResourceType.Sprite)
        {
        }

        public override string GetCode(bool optimize)
        {
            throw new System.NotImplementedException();
        }

        protected override void LoadCode(string code)
        {
            throw new System.NotImplementedException();
        }
    }
}
