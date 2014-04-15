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

        public Envelop(Message _msg, IPEndPoint _endPoint)
        {
            msg = _msg;
            endPoint = _endPoint;
        }

    }
}
