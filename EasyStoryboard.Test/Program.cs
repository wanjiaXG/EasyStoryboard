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
            Storyboard sb = new Storyboard("123.osb");
            sb.Save();
            Console.ReadLine();
        }
    }
}
