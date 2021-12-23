using EasyStoryboard.Core.Attributes;
using EasyStoryboard.Core.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Commands.Base
{
    public abstract class ContainerCommand : ICommand, IEnumerable
    {
        public int StartTime { set; get; }

        protected List<ICommand> Commands = new List<ICommand>();

        public IEnumerator GetEnumerator() => Commands.GetEnumerator();

        public virtual string GetCode()
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

        public override string ToString()
        {
            return GetCode();
        }

        protected abstract string GetHeaderCode();

        public abstract void LoadCode(string code);

        public abstract string GetHeader();

    }
}
