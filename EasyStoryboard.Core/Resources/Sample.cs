using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;

namespace EasyStoryboard.Core
{
    public class Sample : SoundResource
    {
        //Sample,<time>,<layer_num>,"<filepath>",<volume>
        public Sample(string filePath) : base(ResourceType.Sample)
        {

        }
    }
}
