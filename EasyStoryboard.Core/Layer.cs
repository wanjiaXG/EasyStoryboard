using EasyStoryboard.Core.Resource.Base;
using System.Collections.Generic;

namespace EasyStoryboard.Core
{
    public class Layer
    {
        public List<BaseResource> Background { private set; get; } = new List<BaseResource>();

        public List<BaseResource> Fail { private set; get; } = new List<BaseResource>();

        public List<BaseResource> Pass { private set; get; } = new List<BaseResource>();

        public List<BaseResource> Foreground { private set; get; } = new List<BaseResource>();

        public List<BaseResource> Overlay { private set; get; } = new List<BaseResource>();

        public List<BaseResource> SoundSample { private set; get; } = new List<BaseResource>();

    } 
}
