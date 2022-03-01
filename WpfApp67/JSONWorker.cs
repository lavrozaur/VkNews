using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;


namespace WpfApp67
{
    class JSONWorker
    {
        public static void setDataInJson(List<NewsVk> news)
        {
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(List<NewsVk>));
            using (FileStream streamWriter = new FileStream("NewsVk.json",FileMode.Create))
            {
                dataContractJsonSerializer.WriteObject(streamWriter, news);
            }
        }
        public static NewsVk GetStudents()
        {
            if (!File.Exists("NewsVk.json"))
                return null;
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(NewsVk));
            using (FileStream streamWriter = new FileStream("Students.json", FileMode.Open))
            {
                return (NewsVk)dataContractJsonSerializer.ReadObject(streamWriter);
            }
        }
    }
}