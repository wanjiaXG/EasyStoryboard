using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core
{
    public class StoryboardLayer
    {
        public StoryboardLayer()
        {
            Init();
        }

        private void Init()
        {
            string[] names = typeof(StoryboardLayerType).GetEnumNames();
        }
    }

}
