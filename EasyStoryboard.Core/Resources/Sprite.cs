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

        public override string GetCode(Storyboard storyboard, SaveOptions options)
        {
            throw new System.NotImplementedException();
        }

        public override void LoadCode(Storyboard storyboard, string code)
        {
            throw new System.NotImplementedException();
        }

        //Sprite,Pass,Centre,"Text\Play2-HaveFunH.png",320,240
    }
}
