using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;

namespace EasyStoryboard.Core
{
    public class Sample : SoundResource
    {
        public Sample(string filePath) : base(ResourceType.Sample)
        {
            FilePath = filePath;
        }

        //Sample,<time>,<layer_num>,"<filepath>",<volume>
    }
}
