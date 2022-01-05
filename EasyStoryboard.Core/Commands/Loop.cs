using EasyStoryboard.Core.Attributes;
using EasyStoryboard.Core.Commands.Base;
using EasyStoryboard.Core.Enums;
using EasyStoryboard.Core.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using static EasyStoryboard.Core.Util;

namespace EasyStoryboard.Core.Commands
{
    public class Loop : ContainerCommand
    {
        public Loop() : base(CommandType.Loop) { }

        public int Count { set; get; }

        public void Add(ICommand command)
        {
            if(command == null) throw new NotNullException();

            Commands.Add(command);
        }


        public override void LoadCode(string code)
        {
            
        }

        protected override string GetHeaderCode()
        {
            return $"{TypeShortName},{StartTime},{Count}";
        }

    }
}
