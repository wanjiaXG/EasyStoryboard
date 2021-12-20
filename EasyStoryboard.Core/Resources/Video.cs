using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;
using System;

namespace EasyStoryboard.Core.Resources
{
    public class Video : StaticResource
    {
        public Video() : this("") { }

        public Video(string filePath) : base(ResourceType.Video, filePath) { }

        public override string GetCode(Storyboard sb, SaveOptions ops)
        {
            //string fileName = ops.Rename.GetNewName(  )
        }


        //Video,startTime,filename,xOffset,yOffset

    }
}
