using EasyStoryboard.Core.Commands.Base;
using EasyStoryboard.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Commands
{
    public class Trigger : ContainerCommand
    {
        public Trigger() : base(CommandType.Trigger) { }


        public TriggerType TriggerType { set; get; }

        public int EndTime { set; get; }

        public override void LoadCode(string code)
        {

        }


        protected override string GetHeaderCode()
        {
            return $"{TypeShortName},{TriggerType},{StartTime},{EndTime}";
        }
    }
}
