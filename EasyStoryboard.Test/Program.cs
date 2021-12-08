using EasyStoryboard.Core;
using EasyStoryboard.Core.Resources;
using EasyStoryboard.Core.Resources.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"F:\osu\Songs\1607795 Yonder Voice - Shrine Maiden - Eien No Miko\Yonder Voice - Shrine Maiden - Eien No Miko (__Ag).osb";
            Storyboard storyboard = new Storyboard();
            storyboard = Storyboard.Open(path);
            Console.ReadLine();
        }
    }
}
