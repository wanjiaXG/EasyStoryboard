using System.ComponentModel;

namespace EasyStoryboard.Core
{
    public enum ResoureLayerType
    {
        [StoryboardHeader("//Background and Video events")]
        BackgroundOrVideo,

        [StoryboardHeader("//Storyboard Layer 0 (Background)")]
        Background,

        [StoryboardHeader("//Storyboard Layer 1 (Fail)")]
        Fail,

        [StoryboardHeader("//Storyboard Layer 2 (Pass)")]
        Pass,

        [StoryboardHeader("//Storyboard Layer 3 (Foreground)")]
        Foreground,

        [StoryboardHeader("//Storyboard Layer 4 (Overlay)")]
        Overlay,

        [StoryboardHeader("//Storyboard Sound Samples")]
        SampleSound
    }
}
