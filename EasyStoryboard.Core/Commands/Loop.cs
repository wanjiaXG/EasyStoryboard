using EasyStoryboard.Core.Attributes;
using EasyStoryboard.Core.Commands.Base;
using EasyStoryboard.Core.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Commands
{
    public class Loop : ContainerCommand
    {
        public int Count { set; get; }

        public void Add(ICommand command)
        {
            if(command != null)
            {
                Commands.Add(command);
            }
            else
            {
                throw new ArgumentException("Argument can't be null.");
            }
        }

        public override string GetHeader() => "L";

        public override void LoadCode(string code)
        {
            
        }

        protected override string GetHeaderCode()
        {
            return $"{GetHeader()},{Count}";
        }
    }
}
