using EasyStoryboard.Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Commons
{
    class CommonUtil
    {
        public static string GetEnumValue(Enum obj, bool getNum)
        {
            return getNum ?
                obj.GetHashCode().ToString() :
                obj.ToString();
        }

        public static void SetValue(object obj, string name, object value)
        {
            CheckArgument(obj, name, value);

            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
            Type type = obj.GetType();
            
            if(!SetPropertyValue(obj, type.GetProperty(name, flags), value))
            {
                if (!SetFieldValue(obj, type.GetField(name, flags), value))
                {
                    throw new ArgumentException();
                }
            }
        }
       
        public static bool CheckNotNull(params object[] objects)
        {
            if(objects == null)
            {
                return false;
            }
            foreach(var item in objects)
            {
                if(item == null)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool SetFieldValue(object obj, FieldInfo info, object value)
        {
            try
            {
                CheckArgument(obj, info, value);
                info.SetValue(obj, CastValue(info.FieldType, value));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SetPropertyValue(object obj, PropertyInfo info, object value)
        {
            try
            {
                CheckArgument(obj, info, value);
                info.SetValue(obj, CastValue(info.PropertyType, value));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static T CastValue<T>(object value)
        {
            return (T)CastValue(typeof(T), value);
        }

        public static object CastValue(Type type, object value)
        {
            CheckArgument(type, value);
            if (type.IsEnum)
            {
                return Enum.Parse(type, value.ToString());
            }
/*            else if (type.IsValueType)
            {
                return Convert.ChangeType(value, Type.GetTypeCode(type));
            }*/
            else
            {
                return Convert.ChangeType(value, type);
            }
        }
        
        public static void CheckArgument(params object[] objects)
        {
            if (!CheckNotNull(objects))
            {
                throw new ArgumentException();
            }
        }
      
        public static void CkeckArgument(Exception e, params object[] objects)
        {
            if (!CheckNotNull(objects))
            {
                throw e;
            }
        }

        private static char dqm = '"';

        public static List<string> Split(string str, string separator, bool trim = false)
        {
            List<string> list = new List<string>();
            if (!CheckNotNull(str, separator))
            {
                throw new ArgumentException();
            }

            if(str.Length == 0)
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
                
                if (current == dqm)
                {
                    for (i++; i < strs.Length;i++)
                    {
                        current = strs[i];
                        if(current == dqm)
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

    }
}
