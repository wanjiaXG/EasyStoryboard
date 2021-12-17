using EasyStoryboard.Core;
using EasyStoryboard.Core.Resources;
using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Storyboard sb = new Storyboard("123.osb");
            sb.Save();

            Sample sample = new Sample("sss");
            sb.Add(sample);
            Console.ReadLine();
        }
    }
}
