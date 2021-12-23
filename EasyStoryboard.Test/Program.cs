using EasyStoryboard.Core;
using EasyStoryboard.Core.Commands;
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
            /*            string path = @"F:\osu\Songs\1607795 Yonder Voice - Shrine Maiden - Eien No Miko\Yonder Voice - Shrine Maiden - Eien No Miko (__Ag).osb";
                        path = @"D:\Program Files\osu!\Songs\848003 Culprate - Aurora\Culprate - Aurora (BOUYAAA).osb";
                        Storyboard storyboard = Storyboard.Open(path);
                        Console.WriteLine(storyboard.BaseDirectory);
                        Console.WriteLine(storyboard.FileName);

                        Console.ReadLine();


                        FileInfo info = new FileInfo(@"C:\ss\dcsd\df\xc\cvsd\v.osb");
                        Console.WriteLine(info.Exists);
                        Console.WriteLine(info.Name);
                        Console.WriteLine(info.DirectoryName);

                        Console.WriteLine((LayerType)(-100));*/

            //string[] vs = typeof(StoryboardLayerType).GetEnumNames(); foreach (var item in vs) Console.WriteLine(item); ;

            Fade fade = new Fade();
            fade.LoadCode("F,4,2121,1212,0.5,0.9");
            Console.WriteLine(fade);

            Loop loop = new Loop();
            loop.Add(fade);
            loop.Add(fade);
            loop.Add(fade);
            loop.Add(fade);

            Loop l2 = new Loop();
            l2.Add(fade);
            l2.Add(fade);
            l2.Add(fade);
            l2.Add(fade);

            Loop l3 = new Loop();
            l3.Add(fade);
            l3.Add(fade);
            l3.Add(fade);
            l3.Add(fade);

            l2.Add(l3);
            loop.Add(l2);
            loop.Add(fade);
            loop.Add(fade);
            loop.Add(fade);
            loop.Add(fade);

            Console.WriteLine(loop);

            Console.WriteLine("");

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
