using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HRManagerDataAccess
{
    public static class SerializeHelper
    {
        public static void Serialize<T>(T t, string fileName) 
        {
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
            xmlFormat.Serialize(fStream, t);
            fStream.Close();
            Console.WriteLine(fStream.ToString());
        }

        public static T DeSerialize<T>(string fileName)
        {
           Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
            XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
           var reslut =  (T)xmlFormat.Deserialize(fStream);
           fStream.Close();

           return reslut;
          
        }
    }
}
