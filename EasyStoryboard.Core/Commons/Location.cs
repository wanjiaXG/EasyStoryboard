using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Commons
{
    public class Location
    {
        public int X { set; get; }
        public int Y { set; get; }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
