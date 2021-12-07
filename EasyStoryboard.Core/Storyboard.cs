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

        internal List<Video> Video { get; } = new List<Video>();
        internal List<GraphicsResource> Background { get; } = new List<GraphicsResource>();
        internal List<GraphicsResource> Pass { get; } = new List<GraphicsResource>();
        internal List<GraphicsResource> Fail { get; } = new List<GraphicsResource>();
        internal List<GraphicsResource> Foreground { get; } = new List<GraphicsResource>();
        internal List<GraphicsResource> Overlay { get; } = new List<GraphicsResource>();
        internal List<SoundResource> SoundSample { get; } = new List<SoundResource>();

        /*        public string BaseDirectory { private set; get; }

                private string _FilePath;
                public string FilePath 
                {
                    set
                    {
                        if (string.IsNullOrWhiteSpace(value))
                        {
                            throw new ArgumentException("FilePath can't be null.");
                        }

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
                public string ResourcePath { set; get; }*/

        public IEnumerable<Resource> GetAllResource()
        {
            foreach(var item in Video)
            {
                yield return item;
            }

            foreach (var item in Background)
            {
                yield return item;
            }

            foreach (var item in Fail)
            {
                yield return item;
            }

            foreach(var item in Pass)
            {
                yield return item;
            }

            foreach (var item in Foreground)
            {
                yield return item;
            }

            foreach (var item in Overlay)
            {
                yield return item;
            }

            foreach (var item in SoundSample)
            {
                yield return item;
            }
        }

        public Storyboard() { }

/*        public Storyboard(string filePath)
        {
            FilePath = filePath;
        }
        public Storyboard(string filePath, string resourcePath) : this(filePath)
        {
            ResourcePath = resourcePath;
        }*/

        public void Add(Resource resource)
        {
            if(resource == null)
            {
                throw new ArgumentException("Resource can't be null.");
            }
            else
            {
                switch(resource.)

                this.Resources.Add(resource);
            }
        }
        public void AddRange(IEnumerable<Resource> collection)
        {
            if (collection == null)
            {
                throw new ArgumentException("Collection can't be null.");
            }
            else
            {
                foreach(var item in collection)
                {
                    Add(item);
                }
            }
        }



        public void Append(Storyboard sb)
        {
            if (sb == null) throw new ArgumentException("Argument is null, can't append.");

            if (Equals(sb)) throw new ArgumentException("Can't append self.");

            foreach(Resource res in sb.Resources)
            {
                this.Resources.Add(res);
            }

/*            Layers.Video.AddRange(sb.Layers.Video);
            Layers.Background.AddRange(sb.Layers.Background);
            Layers.Fail.AddRange(sb.Layers.Fail);
            Layers.Pass.AddRange(sb.Layers.Pass);
            Layers.Foreground.AddRange(sb.Layers.Foreground);
            Layers.Overlay.AddRange(sb.Layers.Overlay);
            Layers.SoundSample.AddRange(sb.Layers.SoundSample);*/
        }

        #region Build
        public void Save(string osbPath, string resourcePath, bool optimize)
        {
            //Background and Video events
            //Storyboard Layer 0 (Background)
            //Storyboard Layer 1 (Fail)
            //Storyboard Layer 2 (Pass)
            //Storyboard Layer 3 (Foreground)
            //Storyboard Layer 4 (Overlay)
            //Storyboard Sound Samples 
        }
        public void Save(string osbPath)
        {
            Save(osbPath, null, false);
        }

        public void Save(string osbPath, bool optimize)
        {
            Save(osbPath, null, optimize);
        }
        #endregion


        

        public static Storyboard Parse(string code)
        {
            return new Storyboard();
        }

        #region Open
        public static Storyboard Open(FileStream stream, Encoding encoding)
        {
            using(StreamReader sr = new StreamReader(stream, encoding))
            {
                Storyboard sb = Parse(sr.ReadToEnd());
                //sb.FilePath = stream.Name;
                return sb;
            }
        }

        public static Storyboard Open(FileStream stream)
        {
            return Open(stream, Encoding.UTF8);
        }

        public static Storyboard Open(string file, Encoding encoding)
        {
            if (File.Exists(file))
            {
                using (FileStream stream = File.OpenRead(file))
                {
                    return Open(stream, encoding);
                }
            }
            else
            {
                throw new FileNotFoundException("", file);
            }
        }

        public static Storyboard Open(string file)
        {
            return Open(file, Encoding.UTF8);
        }

        #endregion
    }
}
