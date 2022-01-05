using EasyStoryboard.Core.Attributes;
using EasyStoryboard.Core.Commands;

namespace EasyStoryboard.Core.Enums
{
    public enum CommandType
    {
        [CommandType("F", Type = typeof(Fade))]
        Fade,

        [CommandType("L", Type = typeof(Loop))]
        Loop,

        [CommandType("M", Type = typeof(Move))]
        Move,

        [CommandType("MX", Type = typeof(MoveX))]
        MoveX,

        [CommandType("MY", Type = typeof(MoveY))]
        MoveY,

        [CommandType("P", Type = typeof(Parmenter))]
        Parmenter,

        [CommandType("R", Type = typeof(Rotate))]
        Rotate,

        [CommandType("S", Type = typeof(Scale))]
        Scale,

        [CommandType("T", Type = typeof(Trigger))]
        Trigger,

        [CommandType("V", Type = typeof(VectorScale))]
        VectorScale
    }
}
