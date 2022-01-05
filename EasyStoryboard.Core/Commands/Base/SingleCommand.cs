using EasyStoryboard.Core.Attributes;
using EasyStoryboard.Core.Enums;
using EasyStoryboard.Core.Exceptions;
using System;
using System.Reflection;

using static EasyStoryboard.Core.Util;

namespace EasyStoryboard.Core.Commands.Base
{
    public abstract class SingleCommand : ICommand
    {
        public int StartTime { set; get; }

        public int EndTime { set; get; }

        public EasingType EasingType { set; get; }

        public CommandType CommandType { get; }

        public string TypeShortName { get; }

        public SingleCommand(CommandType type)
        {
            CommandType = type;
            MemberInfo memberInfo = typeof(CommandType).GetMember(CommandType.ToString())[0];
            CommandTypeAttribute attr = (CommandTypeAttribute)memberInfo.GetCustomAttributes(typeof(CommandTypeAttribute), false)[0];
            TypeShortName = attr.Header;
        }

        protected string GetPreCode() => $"{TypeShortName},{(int)EasingType},{StartTime},{EndTime}";

        public abstract void LoadCode(string code);

        protected void SetEasingType(string value)
        {
            if (Enum.TryParse(value, out EasingType easingType))
            {
                EasingType = easingType;
            }
            else
            {
                throw new UnknowTypeException(value);
            }
        }

        protected void CheckCommandType(string value)
        {
            if (!TypeShortName.Equals(value))
            {
                throw new ArgumentException($"CommandType is not {CommandType}.");
            }
        }

        protected void SetStartTime(string value)
        {
            if (int.TryParse(value, out int time))
            {
                StartTime = time;
            }
            else
            {
                throw new NotNumberException(value);
            }
        }
        
        protected void SetEndTime(string value)
        {
            if (int.TryParse(value, out int time))
            {
                EndTime = time;
            }
            else
            {
                throw new NotNumberException(value);
            }
        }

        public override string ToString()=> GetCode();

        public abstract string GetCode();
    }
}
