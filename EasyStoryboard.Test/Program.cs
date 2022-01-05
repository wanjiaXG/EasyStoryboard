using EasyStoryboard.Core;
using EasyStoryboard.Core.Commands;
using EasyStoryboard.Core.Exceptions;
using EasyStoryboard.Core.Resources;
using EasyStoryboard.Core.Resources.Base;
using EasyStoryboard.Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using static EasyStoryboard.Core.Util;

namespace EasyStoryboard.Test
{
    class Program
    {
        public static T ParseNumberValue<T>(string value)
        {
            Type type = typeof(T);
            try
            {
                object result = type.InvokeMember("Parse",
                BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public, null, null,
                args: new object[] { value });
                return (T)result;
            }
            catch
            {
                throw new NotNumberException(value, type);
            }
        }

        static void Main(string[] args)
        {
            Fade fade = new Fade();
            fade.LoadCode("F,4,2121,1212,0.5,0.9");

            Loop loop = new Loop();
            loop.Add(fade);
            loop.Add(fade);
            loop.Add(fade);
            loop.Add(fade);

            fade = new Fade();
            fade.LoadCode("F,4,2121,1212,0.5,0.6");
            Loop l2 = new Loop();
            l2.Add(fade);
            l2.Add(fade);
            l2.Add(fade);
            l2.Add(fade);

            fade = new Fade();
            fade.LoadCode("F,4,2121,1212,0.5,0.4");
            Loop l3 = new Loop();
            l3.Add(fade);
            l3.Add(fade);
            l3.Add(fade);
            l3.Add(fade);

            fade = new Fade();
            fade.LoadCode("F,4,2121,1212,0.5,0.2");
            l2.Add(l3);
            loop.Add(l2);
            loop.Add(fade);
            loop.Add(fade);
            loop.Add(fade);
            loop.Add(fade);

            Console.WriteLine(loop);
            Console.WriteLine("--------------------------");

            Loop loop2 = new Loop();
            string sc = loop.GetCode();
            loop2.LoadCode(sc);
            Console.WriteLine(loop2);
            Console.ReadLine();



            Options options = new Options();
            options.Optimize = false;
            options.OuputDirectory = @"D:\\\\\dist";


            Storyboard sb = new Storyboard("a.osb");
            sb.BaseDirectory = @"D:";

            Background background = new Background();
            background.LoadCode(sb.BaseDirectory, "0,256,\"SB/demo.png\",320,450");
            Console.WriteLine(background.GetCode(options));
            Console.WriteLine();





            string code = "5,1236,1,\"SB/demo.png\",56";
            Sample s = new Sample();
            s.LoadCode(sb.BaseDirectory, code);
            


            

            if (Directory.Exists(options.OuputDirectory))
            {
                new DirectoryInfo(options.OuputDirectory).Delete(true);
            }

            Console.WriteLine(s.GetCode(options));
            Console.WriteLine();


            Sample sample = new Sample(@"D:", @"\\1\\demo.png");
            sample.Offset = 2563;
            Console.WriteLine(sample.BaseDirectory);
            Console.WriteLine(sample.RelativePath);
            Console.WriteLine(sample.AbsoluteFilePath);
            Console.WriteLine(sample.GetCode(options));

            sample = new Sample(@"D:\2\demo.png");
            sample.Offset = 2563;
            Console.WriteLine(sample.BaseDirectory);
            Console.WriteLine(sample.RelativePath);
            Console.WriteLine(sample.AbsoluteFilePath);
            Console.WriteLine(sample.GetCode(options));

            sample = new Sample(@"D:\3\demo.png");
            sample.Offset = 2563;
            Console.WriteLine(sample.BaseDirectory);
            Console.WriteLine(sample.RelativePath);
            Console.WriteLine(sample.AbsoluteFilePath);
            Console.WriteLine(sample.GetCode(options));

            sample = new Sample(@"D:\4\demo.png");
            sample.Offset = 2563;
            Console.WriteLine(sample.BaseDirectory);
            Console.WriteLine(sample.RelativePath);
            Console.WriteLine(sample.AbsoluteFilePath);
            Console.WriteLine(sample.GetCode(options));

            Console.ReadLine();
        }
    }
}
