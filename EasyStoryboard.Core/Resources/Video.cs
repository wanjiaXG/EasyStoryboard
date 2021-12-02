using EasyStoryboard.Core.Common;
using EasyStoryboard.Core.Resources.Base;

namespace EasyStoryboard.Core.Resources
{
    public class Video : GraphicsResource
    {
        public Video(string filePath) : base(Enum.ResourceType.Video) 
        {
            FilePath = filePath;
        }

        public Video(string filePath, SBLocation location):this(filePath)
        {
            Location = location;
        }

        public Video SetOffset(int offset)
        {
            Offset = offset;
            return this;
        }

        public Video SetLocation(SBLocation location)
        {
            Location = location;
            return this;
        }

        public Video SetFilePath(string filePath)
        {
            FilePath = filePath;
            return this;
        }

        public override string GetCode(bool optimize)
        {
            return $"{GetResourceType(optimize)},{Offset},\"{FilePath}\",{X},{Y}";
        }

        public override string ToString()
        {
            return GetCode(false);
        }
    }
}
