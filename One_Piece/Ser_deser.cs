using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One_Piece
{
    internal class Ser_deser
    {
        public static void Ser<T>(T a, string b)
        {
            string desctop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(a);
            File.WriteAllText(desctop + "\\" + b, json);
            
        }
        public static T Des<T>(string filename)
        {
            string desctop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(desctop +"\\"+filename);
            T a = JsonConvert.DeserializeObject<T>(json);
            return a;
        }
    }
}
