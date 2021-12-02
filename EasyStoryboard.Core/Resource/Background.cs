using EasyStoryboard.Core.Resource.Base;

namespace EasyStoryboard.Core.Resource
{
    public class Background : BaseResource
    {
        public Background() : base(Enum.ResourceType.Background) { }

        public string ImagePath { set; get; }

        public Background(string file) : this()
        {
            ImagePath = file;
        }

        public override string GetCode(bool optimize)
        {
            return 
        }
    }
}
