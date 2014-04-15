using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;

namespace CommunicationSubsystem
{
    public class MainParamParser
    {
        private string str_ip;
        private string str_port;
     
        // After the constructor executed, these are available.
        public IPAddress ip { get; private set; }
        public int port { get; private set; }


        // command line parameter order: str_param[0] : ip; str_param[1]
        public MainParamParser(string[] str_param)
        {
            str_ip = str_param[0];
            System.Text.UnicodeEncoding encoding = new System.Text.UnicodeEncoding();
            byte[] bts_ip = encoding.GetBytes(str_ip);
            ip = new IPAddress(bts_ip);

            str_port = str_param[1];
            port = int.Parse(str_port);
        }
    }
}
