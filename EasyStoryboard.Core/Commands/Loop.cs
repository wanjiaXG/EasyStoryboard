using EasyStoryboard.Core.Commands.Base;
using EasyStoryboard.Core.Enums;
using System.Collections.Generic;
using static EasyStoryboard.Core.Util;

namespace EasyStoryboard.Core.Commands
{
    public class Loop : ContainerCommand
    {
        public Loop() : base(CommandType.Loop) { }

        public int Count { set; get; }

        protected override string GetHeaderCode()
        {
            return $"{TypeShortName},{StartTime},{Count}";
        }

        protected override void LoadHeaderCode(string code)
        {
            List<string> list = Split(code, ",", true);
            CheckList(list, 3);
            CheckCommandType(list[0]);
            StartTime = ParseNumber<int>(list[1]);
            Count = ParseNumber<int>(list[2]);
        }

    }
}
