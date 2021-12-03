using System.IO;
using System.Text;

namespace EasyStoryboard.Core
{
    public class Storyboard
    {
        public static int ScreenXMin = -110;
        public static int ScreenXMax = 750;
        public static int ScreenYMin = 0;
        public static int ScreenYMax = 480;
        public static int CenterX = 320;
        public static int CenterY = 240;
        private Storyboard() { }

        public static Storyboard Parse(string code)
        {
            return null;
        }

        public static Storyboard Open(FileStream stream, Encoding encoding)
        {
            using(StreamReader sr = new StreamReader(stream, encoding))
            {
                Storyboard sb = Parse(sr.ReadToEnd());
                sb.FilePath = stream.Name;
                return sb;
            }
        }

        public static Storyboard Open(FileStream stream)
        {
            return Open(stream, Encoding.Default);
        }

        public static Storyboard Open(string file, Encoding encoding)
        {
            using(FileStream stream = File.OpenRead(file))
            {
                return Open(stream, encoding);
            }
        }

        public static Storyboard Open(string file)
        {
            if (File.Exists(file))
            {
                return Open(file, Encoding.Default);
            }
            else
            {
                throw new Exceptions.FileNotFoundException(file);
            }
        }

        private string _filePath;
        public string FilePath 
        { 
            set
            {
                if (File.Exists(value))
                {
                    FileInfo fileInfo = new FileInfo(value);
                    if(fileInfo == null || fileInfo.Directory == null)
                    {
                        throw new Exceptions.CantGetFileInfoException(value);
                    }
                    MapPath = new FileInfo(value).Directory.FullName;
                    _filePath = value;
                }
                else
                {
                    throw new Exceptions.FileNotFoundException(value);
                }
            }
            get
            {
                return _filePath;
            }
        }

        public string MapPath { private set; get; }

    }
}
