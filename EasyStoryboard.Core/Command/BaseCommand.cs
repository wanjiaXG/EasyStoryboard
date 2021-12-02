using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Command
{
    public abstract class BaseCommand
    {
        public int StartTime { set; get; }

        public int EndTime { set; get; }

    }
}
