using EasyStoryboard.Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyStoryboard.Core.Common
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
            CkeckArgument(obj, name, value);

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
                CkeckArgument(obj, info, value);
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
                CkeckArgument(obj, info, value);
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
            CkeckArgument(type, value);
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
        
        public static void CkeckArgument(params object[] objects)
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

        public static List<string> Parse(string str, string separator)
        {
            List<string> list = new List<string>();
            if(!CheckNotNull(str, separator))
            {
                throw new ArgumentException();
            }
            int separatorLength = separator.Length;
            int index = str.IndexOf(separator);
            if (index == -1)
            {
                if(str.Length > 0)
                {
                    list.Add(str);
                }
            }
            else
            {
                if (str.StartsWith("\""))
                {
                    index = str.Substring(1).IndexOf('"');
                    if(index == -1)
                    {
                        throw new ArgumentException();
                    }
                    else
                    {
                        //0 index+2;
                        list.Add(str.Substring(1, index));
                        if(str.Length > index + 2)
                        {
                            //list.AddRange(Parse(,separator)
                        }
                        //
                    }
                }
                else
                {
                    list.Add(str.Substring(0, index));
                    int startIndex = index + separatorLength;
                    if(startIndex < str.Length)
                    {
                        list.AddRange(Parse(str.Substring(startIndex), separator));
                    }
                }
                

            }
            return list;
        }


    }
}
