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

        public override string GetCode(bool optimize)
        {
            return $"{GetMaterialTypeCode(optimize)},{Offset},{GetLayerCode(optimize)},\"{FilePath}\",{Volume}";
        }

        protected override void LoadCode(string code)
        {
            code.Split(',');
        }
    }
}
