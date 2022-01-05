using EasyStoryboard.Core.Attributes;
using EasyStoryboard.Core.Enums;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EasyStoryboard.Core.Commands.Base
{
    public abstract class ContainerCommand : ICommand, IEnumerable<ICommand>
    {
        public int StartTime { set; get; }

        public string TypeShortName { get; }

        public CommandType CommandType { get; }
        public object CheckList { get; private set; }

        public ContainerCommand(CommandType type)
        {
            CommandType = type;
            MemberInfo memberInfo = typeof(CommandType).GetMember(CommandType.ToString())[0];
            CommandTypeAttribute attr = (CommandTypeAttribute)memberInfo.GetCustomAttributes(typeof(CommandTypeAttribute), false)[0];
            TypeShortName = attr.Header;
        }

        protected List<ICommand> Commands = new List<ICommand>();

        public IEnumerator GetEnumerator() => Commands.GetEnumerator();

        IEnumerator<ICommand> IEnumerable<ICommand>.GetEnumerator() => Commands.GetEnumerator();

        public string GetCode()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetHeaderCode());
            foreach (var item in Commands)
            {
                sb.Append("\r\n").Append(' ');
                if (item is ContainerCommand container)
                {
                    sb.Append(container.GetCode().Replace("\r\n ", "\r\n  "));
                }
                else
                {
                    sb.Append(item.GetCode());
                }
            }
            return sb.ToString();
        }

        public override string ToString() => GetCode();

        protected abstract string GetHeaderCode();
    }
}
