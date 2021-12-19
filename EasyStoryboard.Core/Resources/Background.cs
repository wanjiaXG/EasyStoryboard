using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;
using System.IO;

namespace EasyStoryboard.Core
{
    public class Background : StaticResource
    {
        public Background() : base(ResourceType.Background) { }

        public override string GetCode(Storyboard storyboard, SaveOptions options)
        {
            string path = storyboard.BaseDirectory + "\\" + FilePath;
            return "";
        }

        public override void LoadCode(Storyboard storyboard, string code)
        {

        }
    }
}
