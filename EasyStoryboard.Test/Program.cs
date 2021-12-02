using EasyStoryboard.Core;
using EasyStoryboard.Core.Resources;
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
            Video video = new Video("a.avi");
            Console.WriteLine(video);
            Console.ReadLine();
        }
    }
}
