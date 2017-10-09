using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TimetableWpf
{
    public class DataManager
    {
        public static T Load<T>(string filename) where T : class, new()
        {
            T returnedList = new T();
            if (File.Exists(filename))
            {
                FileInfo file = new FileInfo(filename);
                if (file.Length != 0)
                {
                    using (StreamReader streamReader = new StreamReader(filename))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                        returnedList = (T)xmlSerializer.Deserialize(streamReader);
                    }
                }
            }
            return returnedList;
        }
        public static void Save<T>(T collection, string filename) where T : class
        {
            if (!File.Exists(filename))
                File.Create(filename).Close();
            if (collection != null)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                var streamWriter = new StreamWriter(filename, false);
                xmlSerializer.Serialize(streamWriter, collection);
                streamWriter.Close();
            }
        }
    }
}
