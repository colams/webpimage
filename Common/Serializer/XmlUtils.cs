using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Common.Serializer
{
    public class XmlUtils
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string ObjectToXml<T>(T obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(typeof(T));
            try
            {
                //序列化对象
                xml.Serialize(Stream, obj);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            Stream.Position = 0;
            string str = string.Empty;
            using (var reader = new StreamReader(Stream))
            {
                str = reader.ReadToEnd();
                reader.Close();
            }

            return str;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T XmlToObject<T>(Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(typeof(T));
            return (T)xmldes.Deserialize(stream);
        }

        /// <summary>
        /// xml反序列化
        /// </summary>
        /// <param name="xml">xml字符串</param>
        /// <param name="objType">对象类型</param>
        /// <returns></returns>
        public static T XmlToObject<T>(string xml)
        {
            T t = default(T);
            if (string.IsNullOrWhiteSpace(xml))
            {
                return t;
            }
            using (var reader = new StringReader(xml))
            {
                var ser = new XmlSerializer(typeof(T));
                t = (T)ser.Deserialize(reader);
            }
            return t;
        }
    }
}
