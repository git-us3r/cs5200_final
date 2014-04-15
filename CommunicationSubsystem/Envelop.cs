using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Net;
using System.Net.Sockets;

using Common;
using Messages;

namespace CommunicationSubsystem
{
    public class Envelop
    {
        public IPEndPoint endPoint { get; set; }
        public Message msg { get; set; }
        public byte[] msg_bytes { get; set; }

        public Envelop(Message _msg, IPEndPoint _endPoint)
        {
            msg = _msg;
            endPoint = _endPoint;
        }


        // An overloaded ctor to facilitate the job of UDPClient.
        public Envelop(byte[] _msg_bytes, IPEndPoint _endPoint)
        {
            endPoint = _endPoint;
            msg_bytes = _msg_bytes;
        }

    }
}
