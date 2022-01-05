using EasyStoryboard.Core.Attributes;
using EasyStoryboard.Core.Enums;
using EasyStoryboard.Core.Exceptions;
using System;
using System.Reflection;

using static EasyStoryboard.Core.Util;

namespace EasyStoryboard.Core.Commands.Base
{
    public abstract class SingleCommand : BaseCommand
    {
        public int EndTime { set; get; }

        public EasingType EasingType { set; get; }

        public SingleCommand(CommandType type) : base(type) { }

        protected string GetPreCode() => $"{TypeShortName},{(int)EasingType},{StartTime},{EndTime}";

        public override string ToString()=> GetCode();

    }
}
