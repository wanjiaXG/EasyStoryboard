using EasyStoryboard.Core.Attributes;

namespace EasyStoryboard.Core.Enums
{
    public enum CommandType
    {
        [Header("F")]
        Fade,

        [Header("L")]
        Loop,

        [Header("M")]
        Move,

        [Header("MX")]
        MoveX,

        [Header("MY")]
        MoveY,

        [Header("P")]
        Parmenter,

        [Header("R")]
        Rotate,

        [Header("S")]
        Scale,

        [Header("T")]
        Trigger,

        [Header("V")]
        VectorScale
    }
}
