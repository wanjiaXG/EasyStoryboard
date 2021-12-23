using EasyStoryboard.Core.Attributes;
using System.ComponentModel;

namespace EasyStoryboard.Core
{
    public enum ResoureLayerType
    {
        [Header("//Background and Video events")]
        BackgroundOrVideo,

        [Header("//Storyboard Layer 0 (Background)")]
        Background,

        [Header("//Storyboard Layer 1 (Fail)")]
        Fail,

        [Header("//Storyboard Layer 2 (Pass)")]
        Pass,

        [Header("//Storyboard Layer 3 (Foreground)")]
        Foreground,

        [Header("//Storyboard Layer 4 (Overlay)")]
        Overlay,

        [Header("//Storyboard Sound Samples")]
        SampleSound
    }
}
