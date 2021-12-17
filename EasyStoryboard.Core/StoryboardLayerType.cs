using System.ComponentModel;

namespace EasyStoryboard.Core
{
    public enum StoryboardLayerType
    {
        [Description("//Background and Video events")]
        BackgroundOrVideo,

        [Description("//Storyboard Layer 0 (Background)")]
        Background,

        [Description("//Storyboard Layer 1 (Fail)")]
        Fail,

        [Description("//Storyboard Layer 2 (Pass)")]
        Pass,

        [Description("//Storyboard Layer 3 (Foreground)")]
        Foreground,

        [Description("//Storyboard Layer 4 (Overlay)")]
        Overlay,

        [Description("//Storyboard Sound Samples")]
        SampleSound
    }
}
