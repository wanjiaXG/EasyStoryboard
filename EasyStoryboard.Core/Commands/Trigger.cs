using EasyStoryboard.Core.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Commands
{
    public class Trigger : ContainerCommand
    {
        public int EndTime { set; get; }

        public override void LoadCode(string code)
        {
            throw new NotImplementedException();
        }

        public override string GetHeader() => "T";

        protected override string GetHeaderCode()
        {
            return $"{GetHeader()},{StartTime},{EndTime}";
        }
    }
}
