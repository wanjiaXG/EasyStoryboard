namespace EasyStoryboard.Core
{
    public class OsbBuilder
    {
        public bool Optimize { set; get; } = false;

        public IRename Rename { set; get; }

        public string ResourceDirectory { set; get; }

    }
}
