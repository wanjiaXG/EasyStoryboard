﻿using EasyStoryboard.Core.Commands.Base;
using EasyStoryboard.Core.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Commands
{
    public class MoveY : SingleCommand
    {
        public MoveY() : base(CommandType.MoveY) { }

        public override string GetCode()
        {
            throw new NotImplementedException();
        }

        public override void LoadCode(string code)
        {
            throw new NotImplementedException();
        }

        internal override void LoadCode(List<string> args)
        {
            throw new NotImplementedException();
        }
    }
}
