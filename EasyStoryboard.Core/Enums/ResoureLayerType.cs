using EasyStoryboard.Core.Attributes;
using System.ComponentModel;

namespace EasyStoryboard.Core
{
    public enum ResoureLayerType
    {
        [CommandType("//Background and Video events")]
        BackgroundOrVideo,

        [CommandType("//Storyboard Layer 0 (Background)")]
        Background,

        [CommandType("//Storyboard Layer 1 (Fail)")]
        Fail,

        [CommandType("//Storyboard Layer 2 (Pass)")]
        Pass,

        [CommandType("//Storyboard Layer 3 (Foreground)")]
        Foreground,

        [CommandType("//Storyboard Layer 4 (Overlay)")]
        Overlay,

        [CommandType("//Storyboard Sound Samples")]
        SampleSound
    }
}
