using EasyStoryboard.Core.Attributes;
using EasyStoryboard.Core.Enums;
using EasyStoryboard.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Commands.Base
{
    public abstract class BaseCommand
    {
        public int StartTime { set; get; }

        protected string TypeShortName { get; }

        public CommandType CommandType { get; }

        internal BaseCommand(CommandType type)
        {
            CommandType = type;
            MemberInfo memberInfo = typeof(CommandType).GetMember(CommandType.ToString())[0];
            CommandTypeAttribute attr = (CommandTypeAttribute)memberInfo.GetCustomAttributes(typeof(CommandTypeAttribute), false)[0];
            TypeShortName = attr.Header;
        }

        public abstract string GetCode();

        private static readonly Dictionary<string, Type> CommandTypes;

        static BaseCommand()
        {
            CommandTypes = new Dictionary<string, Type>();
            foreach (object item in Enum.GetValues(typeof(CommandType)))
            {
                if (item is CommandType type)
                {
                    MemberInfo memberInfo = typeof(CommandType).GetMember(type.ToString())[0];
                    CommandTypeAttribute attr = (CommandTypeAttribute)memberInfo.GetCustomAttributes(typeof(CommandTypeAttribute), false)[0];
                    CommandTypes.Add(attr.Header, attr.Type);
                }
            }
        }

        protected static BaseCommand GetCommandType(string shortName)
        {
            if (!CommandTypes.ContainsKey(shortName)) throw new UnknowTypeException(shortName);
            return (BaseCommand)CommandTypes[shortName].GetConstructor(Type.EmptyTypes).Invoke(new object[0]);
        }

        protected void CheckCommandType(string value)
        {
            if (!TypeShortName.Equals(value))
            {
                throw new ArgumentException($"CommandType is not {CommandType}.");
            }
        }
    }
}
