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
            Background resource = new Background();
            resource.Load("0,0,Servent X Service OP.png,");
            Console.WriteLine(resource);
            Console.ReadLine();
        }
    }
}
