using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;

namespace EasyStoryboard.Core
{
    public class Sample : SoundResource
    {
        public Sample(string filePath) : base(ResourceType.Sample, filePath)
        {

        }

        public override void Load(string code)
        {

        }

        //Sample,<time>,<layer_num>,"<filepath>",<volume>

    }
}
