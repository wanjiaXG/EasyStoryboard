using EasyStoryboard.Core.Resources;
using EasyStoryboard.Core.Resources.Base;
using System.Collections.Generic;

namespace EasyStoryboard.Core
{
    public class Layers
    {
        public List<Video> Video { get; } = new List<Video>();
        public List<GraphicsResource> Background { get; } = new List<GraphicsResource>();
        public List<GraphicsResource> Pass { get; } = new List<GraphicsResource>();
        public List<GraphicsResource> Fail { get; } = new List<GraphicsResource>();
        public List<GraphicsResource> Foreground { get; } = new List<GraphicsResource>();
        public List<GraphicsResource> Overlay { get; } = new List<GraphicsResource>();
        public List<SoundResource> SoundSample { get; } = new List<SoundResource>();

        private Layers() { }

        internal static Layers NewInstance() => new Layers();

    }
}
