using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;


namespace WpfApp67
{
    [DataContract]
    class NewsVk
    {
        [DataMember]
        public string Text;
        [DataMember]
        public string Id;
        //public string[] Photos;
        //public string[] Href;
    }
}
