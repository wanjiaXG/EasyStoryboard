using EasyStoryboard.Core.Commons;
using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;

namespace EasyStoryboard.Core.Resources
{
    public class Video : StaticResource
    {
        public Video() : base(ResourceType.Video) { }

        public override string GetCode(Storyboard storyboard, SaveOptions options)
        {
            throw new System.NotImplementedException();
        }

        public override void LoadCode(Storyboard storyboard, string code)
        {
            throw new System.NotImplementedException();
        }


        //Video,startTime,filename,xOffset,yOffset

    }
}
