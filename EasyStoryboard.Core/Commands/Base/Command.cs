using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Commands.Base
{
    public abstract class Command
    {
        public int StartTime { set; get; }

        public int EndTime { set; get; }

    }
}
