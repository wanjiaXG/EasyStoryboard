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

        internal List<StaticResource> StaticResource { get; } = new List<StaticResource>();
        internal List<DynamicResource> Background { get; } = new List<DynamicResource>();
        internal List<DynamicResource> Pass { get; } = new List<DynamicResource>();
        internal List<DynamicResource> Fail { get; } = new List<DynamicResource>();
        internal List<DynamicResource> Foreground { get; } = new List<DynamicResource>();
        internal List<DynamicResource> Overlay { get; } = new List<DynamicResource>();
        internal List<SoundResource> SoundSample { get; } = new List<SoundResource>();
        public IEnumerable<Resource> GetAllResource()
        {
            foreach(var item in StaticResource)
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

        public void Add(Resource resource)
        {
            if(resource == null)
            {
                throw new ArgumentException("Resource can't be null.");
            }
            else
            {
                //Video
                //Background
                //Pass
                //Fail
                //Foreground
                //SoundSample
                if(resource is StaticResource sRes)
                {
                    StaticResource.Add(sRes);
                }
                else if(resource is DynamicResource dRes)
                {
                    switch (dRes.LayerType)
                    {
                        case Resources.Enums.LayerType.Background:
                            Background.Add(dRes);
                            break;

                        case Resources.Enums.LayerType.Fail:
                            Fail.Add(dRes);
                            break;

                        case Resources.Enums.LayerType.Pass:
                            Pass.Add(dRes);
                            break;

                        case Resources.Enums.LayerType.Foreground:
                            Foreground.Add(dRes);
                            break;

                        case Resources.Enums.LayerType.Overlay:
                            Overlay.Add(dRes);
                            break;
                        default:
                            throw new ArgumentException("Unknow resource object.");
                    }
                }
                else if(resource is SoundResource ssRes)
                {
                    SoundSample.Add(ssRes);
                }
                else
                {
                    throw new ArgumentException("Unknow resource object.");
                }
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

            foreach(Resource res in sb.GetAllResource())
            {
                Add(res);
            }
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
            List<string> list = Commons.CommonUtil.Split(code, "\n");
            foreach(var line in list)
            {
                
            }
            return new Storyboard();
        }

        #region Open
        public static Storyboard Open(FileStream stream, Encoding encoding)
        {
            using(StreamReader sr = new StreamReader(stream, encoding))
            {
                return Parse(sr.ReadToEnd());
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
