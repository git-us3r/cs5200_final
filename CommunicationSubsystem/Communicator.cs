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
        public int port { get; set; }
        public Socket socket { get; set; }
        private const int MAX_BUFFER_SIZE = 1024;

        public Communicator(int _port = 0, Socket _socket = null)
        {
            // 
            port = _port;

            if (_socket == null)
            {
                socket = new Socket(SocketType.Dgram, ProtocolType.Udp);
                IPAddress localHost = getLocalHost();
                IPEndPoint ep = new IPEndPoint(localHost, port);
                socket.Bind(ep);
                socket.ReceiveTimeout = 100;
            }
            else
            {
                socket = _socket;
                socket.ReceiveTimeout = 100;
            }

        }

        public void send(Envelop env)
        {
            // 
            //IPEndPoint localEP = new IPEndPoint(IPAddress.Any, 0);  // let the OS choose the port
            //Socket localSocket = new Socket(SocketType.Dgram, ProtocolType.Udp);
            //localSocket.Bind(localEP);

            ByteList localByteList = new ByteList();
            env.msg.Encode(localByteList);
            byte[] localByteArray = localByteList.ToBytes();


            socket.SendTo(localByteArray, env.endPoint);
            // localSocket.Close();
            //Pingo

        }

        
        // This one will be used by the strategy
        public void send(Message msg, IPEndPoint destinationEndPoint)
        {
            ByteList localByteList = new ByteList();
            msg.Encode(localByteList);
            byte[] localByteArray = localByteList.ToBytes();


            socket.SendTo(localByteArray, destinationEndPoint);
        }



        public Envelop receive()
        {
            //IPEndPoint localEP = new IPEndPoint(IPAddress.Any, this.port);
            //UdpClient udpClient = new UdpClient(localEP);
            //Socket socket =  new Socket(SocketType.Dgram, ProtocolType.Udp);
            //socket.Bind(localEP);
            byte[] byteArray = new byte[MAX_BUFFER_SIZE];   // wtf!

            try
            {
                socket.Receive(byteArray);
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
                //Console.Read();
                return null;
            }

            ByteList byteList = new ByteList();
            byteList.CopyFromBytes(byteArray);

            Message localMsg = Message.Create(byteList);

            Envelop localEnv = new Envelop(localMsg, socket.LocalEndPoint as IPEndPoint);

            return localEnv;
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
