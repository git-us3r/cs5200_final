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
    public class Communicator
    {
        public int localPort { get; set; }
        public UDPClient socket { get; private set; }
        //public Socket socket { get; set; }
        private int MAX_BUFFER_SIZE { get; set; }

        public Communicator(int _port = 0, int _maxBufferSize = 1024)
        {
            localPort = _port;
            MAX_BUFFER_SIZE = _maxBufferSize;
            socket = new UDPClient();
        }

        public void send(Envelop env)
        {

            ByteList localByteList = new ByteList();
            env.msg.Encode(localByteList);
            byte[] localByteArray = localByteList.ToBytes();
            
            socket.Send(localByteArray, env.endPoint);
            

        }

        
        // This one will be used by the strategy
        public void send(Message msg, IPEndPoint destinationEndPoint)
        {
            ByteList localByteList = new ByteList();
            msg.Encode(localByteList);
            byte[] localByteArray = localByteList.ToBytes();


            socket.Send(localByteArray, destinationEndPoint);
        }



        public Envelop receive()
        {

            UPDClientEnvelop udpEnv = socket.Receive();

            if (udpEnv != null)
            {

                ByteList byteList = new ByteList();
                byteList.CopyFromBytes(udpEnv.msg_bytes);       // populate a ByteList object with the contents of byte[]

                Message localMsg = Message.Create(byteList);

                Envelop localEnv = new Envelop(localMsg, udpEnv.remoteEP);

                return localEnv;

            }
            else
            {
                return null;
            }
        }


        public static IPAddress getLocalHost()
        {
            // get local host IP addres
            // routine obtained from stackoverflow:
            // https://stackoverflow.com/questions/1069103/how-to-get-my-own-ip-address-in-c
            ////

            IPHostEntry potentialLocalHosts;
            string str_localhost = "";
            potentialLocalHosts = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in potentialLocalHosts.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    str_localhost = ip.ToString();
                    break;
                }
            }
            return IPAddress.Parse(str_localhost);
         
        }

    }
    // End Class: Communicator
}
