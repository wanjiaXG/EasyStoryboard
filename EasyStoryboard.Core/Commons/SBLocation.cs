using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Commons
{
    public class SBLocation
    {
        public int X { set; get; }
        public int Y { set; get; }

        public SBLocation(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
