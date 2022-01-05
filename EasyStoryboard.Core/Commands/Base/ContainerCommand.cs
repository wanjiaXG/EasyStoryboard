using EasyStoryboard.Core.Enums;
using EasyStoryboard.Core.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using static EasyStoryboard.Core.Util;

namespace EasyStoryboard.Core.Commands.Base
{
    public abstract class ContainerCommand : BaseCommand
    {
        public ContainerCommand(CommandType type) : base(type) { }

        protected List<BaseCommand> Commands = new List<BaseCommand>();

        public IEnumerator GetEnumerator() => Commands.GetEnumerator();

        public override void LoadCode(string code)
        {

            List<List<BaseCommand>> stack = new List<List<BaseCommand>>();
            List<string> list = Split(code, "\r\n");
            if (list.Count < 1) throw new CodeFormatException(code);
            int currentCount = 0;
            foreach(var line in list)
            {
                //获取缩进，判断层级
                int indentCount = GetIndentCount(line);

                //分割参数
                List<string> args = Split(line, ",", true);

                //校验参数
                CheckList(args, 1);
                
                //创建命令对象
                BaseCommand cmd = GetCommandType(args[0]);
                
                //解析代码
                cmd.LoadCode(args);

                //同级
                if(indentCount == currentCount)
                {
                    List<BaseCommand> topList = stack[stack.Count - 1];
                    topList.Add(cmd);
                }
                else if(indentCount == currentCount + 1 && cmd is ContainerCommand container)
                {
                    stack.Add(new List<BaseCommand>());
                    List<BaseCommand> topList = stack[stack.Count - 1];

                    currentCount++;
                }
                
                if(indentCount == currentCount - 1 && indentCount >= 1)
                {
                    List<BaseCommand> commands = stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);
                    if(stack[stack.Count - 1][stack[stack.Count - 1].Count - 1] is ContainerCommand container)
                    {
                        container.Add(commands);
                    }
                    currentCount--;
                }
                else if (indentCount > currentCount)
                {


                    stack.Add(new List<BaseCommand>());
                    stack[stack.Count - 1].Add(cmd);
                    currentCount++;
                }
                else{
                    stack[stack.Count - 1].Add(cmd);
                }
            }

            //赋值
            for(int i = stack.Count - 1; i > 1; i++)
            {
                List<BaseCommand> commands = stack[i];
                stack.RemoveAt(i);
                if (stack[i - 1][stack[i - 1].Count - 1] is ContainerCommand container)
                {
                    container.Add(commands);
                }
            }

            if(stack.Count == 1)
            {
                Commands = stack[0];
            }
            else
            {
                throw new Exception();
            }
        }

        internal override void LoadCode(List<string> args) { }

        protected abstract string GetHeaderCode();

        protected abstract void LoadHeaderCode(string code);

        private int GetIndentCount(string code)
        {
            int count = 0;
            foreach(var item in code.ToCharArray())
            {
                if(item == ' ')
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }

        public override string GetCode()
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

        public void Add(BaseCommand command)
        {
            CheckNotNull(command);
            Commands.Add(command);
        }

        public void Add(IEnumerable<BaseCommand> commands)
        {
            CheckNotNull(commands);
            foreach (var item in commands)
            {
                Add(item);
            }
        }

        public void Remove(BaseCommand command)
        {
            CheckNotNull(command);
            Commands.Remove(command);
        }

        public void Remove(IEnumerable<BaseCommand> commands)
        {
            CheckNotNull(commands);
            foreach(var item in commands)
            {
                Remove(item);
            }
        }

    }
}
