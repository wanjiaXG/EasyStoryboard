using EasyStoryboard.Core.Resources.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using EasyStoryboard.Core.Attributes;
using EasyStoryboard.Core.Commands;

using static EasyStoryboard.Core.Util;

namespace EasyStoryboard.Core
{
    public class Storyboard
    {

        
        public static Storyboard Parse(string code)
        {
            Storyboard sb = new Storyboard();
            List<string> list = Split(code, "\n", true);
            int lineNum = 1;
            foreach (var line in list)
            {
                lineNum++;
            }
            return sb;
        }

        public static Storyboard Open(Stream stream, Encoding encoding)
        {
            if (stream == null)
            {
                throw new IOException($"Stream Can't be null.");
            }
            else
            {
                using (StreamReader sr = new StreamReader(stream, encoding))
                {
                    Storyboard sb = Parse(sr.ReadToEnd());
                    if (stream is FileStream fs)
                    {
                        FileInfo info = new FileInfo(fs.Name);
                        sb.BaseDirectory = info.DirectoryName;
                        sb.FileName = info.Name;
                    }
                    return sb;
                }
            }
        }

        public static Storyboard Open(Stream stream)
        {
            return Open(stream, Encoding.UTF8);
        }

        public static Storyboard Open(string filPath, Encoding encoding)
        {
            if (string.IsNullOrWhiteSpace(filPath)) throw new ArgumentException($"Argument can't be space or null");

            FileInfo info = new FileInfo(filPath);
            if (!info.Exists)
            {
                throw new FileNotFoundException($"Can't open file '{filPath}', file not found.", filPath);
            }
            else
            {
                using (FileStream stream = File.OpenRead(filPath))
                {
                    Storyboard sb = Open(stream, encoding);
                    sb.BaseDirectory = info.DirectoryName;
                    sb.FileName = info.Name;
                    return sb;
                }
            }
        }

        public static Storyboard Open(string file)
        {
            return Open(file, Encoding.UTF8);
        }


        private Dictionary<string, List<ResourceGroup>> Resources;

        private string _BaseDirectory;
        public string BaseDirectory
        {
            set
            {
                if (value != null)
                {
                    _BaseDirectory = new DirectoryInfo(value + "\\").FullName; ;
                }
            }
            get
            {
                return _BaseDirectory;
            }
        }

        public string FileName { set; get; }

        public Storyboard(string filePath = "")
        {
            Resources = new Dictionary<string, List<ResourceGroup>>();
            foreach (var item in typeof(ResoureLayerType).GetEnumNames())
            {
                Resources.Add(item, new List<ResourceGroup>());
            }
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                FileInfo info = new FileInfo(filePath);
                BaseDirectory = info.DirectoryName;
                FileName = info.Name;
            }
        }

        public void Append(Storyboard sb)
        {
            if(sb == null)
            {
                throw new ArgumentException("Arguments can't be null.");
            }
            foreach(var item in Resources)
            {
                
            }
        }


        public void AddRange(IEnumerable<ResourceGroup> groups)
        {
            foreach (var item in groups) Add(item);
        }

        public void AddRange(IEnumerable<Resource> resources)
        {
            foreach (var item in resources) Add(item);
        }

        public void Add(Resource resource)
        {
            Add(new ResourceGroup().Add(resource));
        }

        public void Add(ResourceGroup group)
        {
            ResoureLayerType type = group.StoryboardLayerType;
            List<ResourceGroup> list = Resources[type.ToString()];
            if (!list.Contains(group))
            {
                list.Add(group);
            }
            else
            {
                throw new ArgumentException("ResourceGroup can't be duplicate");
            }
        }

        public void Save(Options options)
        {
            Type type = typeof(ResoureLayerType);

            StringBuilder sb = new StringBuilder();
            sb.Append("[Events]\r\n");
            foreach(var item in type.GetEnumNames())
            {
                MemberInfo memberInfo = type.GetMember(item)[0];
                CommandTypeAttribute attr = (CommandTypeAttribute)memberInfo.GetCustomAttributes(typeof(CommandTypeAttribute), false)[0];

                sb.Append(attr.Header).Append("\r\n");

                foreach(var resGrop in Resources[item])
                {
                    foreach(var res in resGrop.Resources)
                    {
                        //sb.Append(res.GetCode(this, options)).Append("\r\n");
                    }
                }
            }
            File.WriteAllText(BaseDirectory + "\\" + FileName, sb.ToString().TrimEnd());
        }

    }
}
