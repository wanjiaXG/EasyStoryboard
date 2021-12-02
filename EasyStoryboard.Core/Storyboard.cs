using System.IO;
using System.Text;

namespace EasyStoryboard.Core
{
    public class Storyboard
    {

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
                throw new Exception.FileNotFoundException(file);
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
                        throw new Exception.CantGetFileInfoException(value);
                    }
                    MapPath = new FileInfo(value).Directory.FullName;
                    _filePath = value;
                }
                else
                {
                    throw new Exception.FileNotFoundException(value);
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
