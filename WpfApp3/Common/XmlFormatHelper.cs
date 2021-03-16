using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MvvmTest.Common
{
    public static class XmlFormatHelper<T> where T :class
    {
        /// <summary>
        /// 保存对象
        /// </summary>
        /// <param name="t">泛型对象</param>
        /// <param name="filepath">文件路径</param>
        public static void Save_T(T t, string filepath)
        {
            using (Stream fStream = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                new XmlSerializer(typeof(T)).Serialize(fStream, t);
            }
        }

        /// <summary>
        /// 读取对象
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns>泛型对象</returns>
        public static T Read_T(string filepath)
        {
            T t = default(T);
            if (File.Exists(filepath))
            {
                try
                {
                    using (Stream fStream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                    {
                        t = (T)new XmlSerializer(typeof(T)).Deserialize(fStream);
                    }
                }
                catch (Exception ex)
                {
                   // LogHelper.LogException(ex);
                }
            }

            return t;
        }

        /// <summary>
        /// 保存对象集合
        /// </summary>
        /// <param name="ts">泛型对象集合</param>
        /// <param name="filepath">文件路径</param>
        public static void Save_TS(List<T> ts, string filepath)
        {
            using (Stream fStream = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                new XmlSerializer(typeof(List<T>)).Serialize(fStream, ts);
            }
        }

        /// <summary>
        /// 读取对象集合
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns>泛型对象集合</returns>
        public static List<T> Read_TS(string filepath)
        {
            List<T> ts = new List<T>();
            if (File.Exists(filepath))
            {
                try
                {
                    using (Stream fStream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                    {
                        ts = (List<T>)new XmlSerializer(typeof(List<T>)).Deserialize(fStream);
                    }
                }
                catch (Exception ex)
                {
                   //LogHelper.LogException(ex);
                }
            }

            return ts;
        }

        /// <summary>
        /// 保存多类型的基类类型对象
        /// </summary>
        /// <param name="type">基类类型</param>
        /// <param name="extraTypes">拓展类型</param>
        /// <param name="obj">需要保存的对象</param>
        /// <param name="filepath">保存的文件位置</param>
        public static void Save_Base(Type type, Type[] extraTypes, object obj, string filepath)
        {
            XmlSerializer serializer = new XmlSerializer(type, extraTypes);
            using (FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, obj);
            }
        }

        /// <summary>
        /// 读取多类型的基类类型对象
        /// </summary>
        /// <param name="type">基类类型</param>
        /// <param name="extraTypes">拓展类型</param>
        /// <param name="filepath">保存的文件位置</param>
        /// <returns>基类类型对象</returns>
        public static T Read_Base(Type type, Type[] extraTypes, string filepath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(type, extraTypes);
                using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                {
                    return (T)serializer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                //LogHelper.LogException(ex);
            }

            return default(T);
        }
    }
}
