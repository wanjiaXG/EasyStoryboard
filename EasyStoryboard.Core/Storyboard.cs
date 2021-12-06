using EasyStoryboard.Core.Resources;
using EasyStoryboard.Core.Resources.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasyStoryboard.Core
{
    public class Storyboard
    {
        #region static

        public readonly static int ScreenXMin = -110;
        public readonly static int ScreenXMax = 750;

        public readonly static int ScreenYMin = 0;
        public readonly static int ScreenYMax = 480;

        public readonly static int CenterX = 320;
        public readonly static int CenterY = 240;

        #endregion

        public string BaseDirectory { private set; get; }

        private string _FilePath;
        public string FilePath 
        {
            set
            {
                if (File.Exists(value))
                {
                    FileInfo info = new FileInfo(value);
                    BaseDirectory = info.DirectoryName;
                    _FilePath = info.FullName;
                }
                else
                {
                    File.WriteAllBytes(value, new byte[0]);
                    FileInfo info = new FileInfo(value);
                    BaseDirectory = info.DirectoryName;
                    _FilePath = info.FullName;
                    info.Delete();
                }
            }
            get
            {
                return _FilePath;
            }
        }


        #region Build
        public void Build(bool optimize, string resourcePath)
        {
            if (string.IsNullOrWhiteSpace(FilePath))
            {
                throw new FileNotFoundException("No output file specified.");
            }
            //Background and Video events
            //Storyboard Layer 0 (Background)
            //Storyboard Layer 1 (Fail)
            //Storyboard Layer 2 (Pass)
            //Storyboard Layer 3 (Foreground)
            //Storyboard Layer 4 (Overlay)
            //Storyboard Sound Samples

        }

        public void Build(bool optimize)
        {
            Build(optimize, null);
        }

        public void Build(string resourcePath)
        {
            Build(false, resourcePath);
        }

        public void Build()
        {
            Build(false, null);
        }

        #endregion


        public Layers Layers { set; get; } = Layers.GetInstance();

        public void Append(Storyboard sb)
        {
            
            if (sb == null) throw new ArgumentException("Argument is null, can't append.");

            if (Equals(sb)) throw new ArgumentException("Can't append self.");

            Layers.Video.AddRange(sb.Layers.Video);
            Layers.Background.AddRange(sb.Layers.Background);
            Layers.Fail.AddRange(sb.Layers.Fail);
            Layers.Pass.AddRange(sb.Layers.Pass);
            Layers.Foreground.AddRange(sb.Layers.Foreground);
            Layers.Overlay.AddRange(sb.Layers.Overlay);
            Layers.SoundSample.AddRange(sb.Layers.SoundSample);
        }


        


        
        public static Storyboard Parse(string code, StoryboardParseMode mode)
        {
            try
            {

            }
            catch(Exception e)
            {
                if(mode == StoryboardParseMode.Stric)
                {
                    throw e;
                }
            }
            return new Storyboard();
        }

        #region Open
        public static Storyboard Open(FileStream stream, Encoding encoding, StoryboardParseMode mode)
        {
            using(StreamReader sr = new StreamReader(stream, encoding))
            {
                Storyboard sb = Parse(sr.ReadToEnd(), mode);
                sb.FilePath = stream.Name;
                return sb;
            }
        }

        public static Storyboard Open(FileStream stream, StoryboardParseMode mode)
        {
            return Open(stream, Encoding.UTF8, mode);
        }

        public static Storyboard Open(string file, Encoding encoding,StoryboardParseMode mode)
        {
            if (File.Exists(file))
            {
                using (FileStream stream = File.OpenRead(file))
                {
                    return Open(stream, encoding, mode);
                }
            }
            else
            {
                throw new FileNotFoundException("", file);
            }
        }

        public static Storyboard Open(string file, StoryboardParseMode mode = StoryboardParseMode.Stric)
        {
            return Open(file, Encoding.UTF8, mode);
        }

        #endregion
    }
}
