using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enum;

namespace EasyStoryboard.Core
{
    public class Sample : SoundResource
    {
        public Sample(string filePath) : base(ResourceType.Sample)
        {
            FilePath = filePath;
        }

        public override string GetCode(bool optimize)
        {
            return "0,0";
        }
    }
}
