using EasyStoryboard.Core.Attributes;
using EasyStoryboard.Core.Enums;
using EasyStoryboard.Core.Exceptions;
using System;
using System.Reflection;

using static EasyStoryboard.Core.Commons.CommonUtil;

namespace EasyStoryboard.Core.Commands.Base
{
    public abstract class BaseCommand : ICommand
    {
        public int StartTime { set; get; }

        public int EndTime { set; get; }

        public EasingType EasingType { set; get; }

        public CommandType CommandType { private set; get; }

        public string TypeShortName { private set; get; }

        public BaseCommand(CommandType type)
        {
            CommandType = type;
            MemberInfo memberInfo = typeof(CommandType).GetMember(CommandType.ToString())[0];
            HeaderAttribute attr = (HeaderAttribute)memberInfo.GetCustomAttributes(typeof(HeaderAttribute), false)[0];
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
            CheckStrings(value);
            if (!value.Equals(TypeShortName))
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
