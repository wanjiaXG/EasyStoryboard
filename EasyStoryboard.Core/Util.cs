using EasyStoryboard.Core.Attributes;
using EasyStoryboard.Core.Commands.Base;
using EasyStoryboard.Core.Enums;
using EasyStoryboard.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EasyStoryboard.Core
{
    public class Util
    {
        #region Screen Range

        public readonly static int ScreenXMin = -110;

        public readonly static int ScreenXMax = 750;

        public readonly static int ScreenYMin = 0;

        public readonly static int ScreenYMax = 480;

        public readonly static int CenterX = 320;

        public readonly static int CenterY = 240;

        #endregion

        private static readonly Dictionary<string, Type> CommandTypes = new Dictionary<string, Type>();

        static Util(){
            foreach (object item in Enum.GetValues(typeof(CommandType)))
            {
                if(item is CommandType type)
                {
                    MemberInfo memberInfo = typeof(CommandType).GetMember(type.ToString())[0];
                    CommandTypeAttribute attr = (CommandTypeAttribute)memberInfo.GetCustomAttributes(typeof(CommandTypeAttribute), false)[0];
                    CommandTypes.Add(attr.Header, attr.Type);
                }
            }
        }

        public static ICommand GetCommandType(string shortName)
        {
            if (!CommandTypes.ContainsKey(shortName)) throw new UnknowTypeException(shortName);
            return (ICommand)CommandTypes[shortName].GetConstructor(Type.EmptyTypes).Invoke(new object[0]);
        }

        public static void CheckStrings(params string[] objects)
        {
            foreach (var item in objects)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    throw new ArgumentException("Arguments can't be null or space.");
                }
            }
        }

        public static void CheckNotNull(params object[] objects)
        {
            foreach (var item in objects)
            {
                if (item == null)
                {
                    throw new ArgumentException("Arguments can't be null.");
                }
            }
        }


        private static readonly char DoubleQuotationMark = '"';

        public static List<string> Split(string str, string separator, bool trim = false)
        {
            List<string> list = new List<string>();
            CheckStrings(str, separator);

            if (str.Length == 0)
            {
                return list;
            }

            if(separator.Length == 0)
            {
                if (trim)
                {
                    list.Add(str.Trim());
                }
                else
                {
                    list.Add(str);
                }
                
                return list;
            }

            char[] strs = str.ToArray();
            char[] seps = separator.ToCharArray();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strs.Length; i++)
            {
                char current = strs[i];
                
                if (current == DoubleQuotationMark)
                {
                    for (i++; i < strs.Length;i++)
                    {
                        current = strs[i];
                        if(current == DoubleQuotationMark)
                        {
                            break;
                        }
                        else
                        {
                            sb.Append(current);
                        }
                    }
                }
                else
                {
                    bool flag = false;
                    for (int j =0; j < seps.Length; j++)
                    {
                        if(j + i >= strs.Length)
                        {
                            break;
                        }
                        else
                        {
                            if(seps[j] != strs[j + i])
                            {
                                break;
                            }
                        }

                        if(j + 1 >= seps.Length)
                        {
                            flag = true;
                        }
                    }

                    if (flag)
                    {
                        if (trim)
                        {
                            list.Add(sb.ToString().Trim());
                        }
                        else
                        {
                            list.Add(sb.ToString());
                        }
                        sb.Clear();
                    }
                    else
                    {
                        sb.Append(current);
                    }

                }
                if(i + 1 >= strs.Length && sb.Length >= 1)
                {
                    if (trim)
                    {
                        list.Add(sb.ToString().Trim());
                    }
                    else
                    {
                        list.Add(sb.ToString());
                    }
                }
            }

            return list;
        }

        public static T CastValue<T>(object value)
        {
            return (T)CastValue(typeof(T), value);
        }

        public static object CastValue(Type type, object value)
        {
            CheckNotNull(type, value);
            if (type.IsEnum)
            {
                return Enum.Parse(type, value.ToString());
            }
            else
            {
                return Convert.ChangeType(value, type);
            }
        }

        public static string GetEnumValue(Enum obj, bool getNum)
        {
            return getNum ?
                obj.GetHashCode().ToString() :
                obj.ToString();
        }

        public static string GetFileMD5Hash(string path)
        {
            try
            {
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(File.ReadAllBytes(path));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static void CheckList<T>(List<T> list, int minCount)
        {
            if (list == null) throw new NotNullException();
            if (list.Count < minCount) throw new OutOfBoundsException(list.Count, minCount, "");
        }

    }
}
