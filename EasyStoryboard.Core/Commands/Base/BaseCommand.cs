using EasyStoryboard.Core.Attributes;
using EasyStoryboard.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using static EasyStoryboard.Core.Commons.CommonUtil;

namespace EasyStoryboard.Core.Commands.Base
{
    public abstract class BaseCommand : ICommand
    {
        public int StartTime { set; get; }

        public int EndTime { set; get; }

        public EasingType EasingType { set; get; }

        public CommandType CommandType { private set; get; }

        public string Header { private set; get; }

        public BaseCommand(CommandType type)
        {
            CommandType = type;
            MemberInfo memberInfo = typeof(CommandType).GetMember(CommandType.ToString())[0];
            HeaderAttribute attr = (HeaderAttribute)memberInfo.GetCustomAttributes(typeof(HeaderAttribute), false)[0];
            Header = attr.Header;
        }

        public virtual string GetCode() 
        {
            return Header + ","
                    + (int)EasingType + ","
                    + StartTime + ","
                    + EndTime;
        }

        public abstract void LoadCode(string code);


        protected void SetEasingType(string value)
        {
            if (Enum.TryParse(value, out EasingType easingType))
            {
                EasingType = easingType;
            }
            else
            {
                throw new ArgumentException("EasingType is unknow type.");
            }
        }

        protected void CheckCommandType(string value)
        {
            CheckStrings(value);
            if (!value.Equals(Header))
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
                throw new ArgumentException("StartTime is not number.");
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
                throw new ArgumentException("EndTime is not number.");
            }
        }

        public override string ToString()
        {
            return GetCode();
        }

        public string GetHeader() => Header;
    }
}
