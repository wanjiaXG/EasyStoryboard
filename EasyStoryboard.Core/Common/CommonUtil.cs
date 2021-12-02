using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Common
{
    class CommonUtil
    {
        public static string GetEnumValue(Enum obj, bool getNum)
        {
            return getNum ?
                obj.GetHashCode().ToString() :
                obj.ToString();
        }
    }
}
