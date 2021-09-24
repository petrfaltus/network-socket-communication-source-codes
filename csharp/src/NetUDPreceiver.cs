using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace NetUDPreceiver
{
    public class Program
    {
        private static readonly int RECEIVER_PORT = 10000;
        private static readonly int BUFFER_SIZE = 4096;

        public static void Main(string[] args)
        {
            Console.WriteLine("UDP IPv4 datagram socket receiver");

            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                Console.WriteLine("- socket created");

                IPEndPoint receiver = new IPEndPoint(IPAddress.Any, RECEIVER_PORT);

                socket.Bind(receiver);
                Console.WriteLine("- socket bound on port {0}", RECEIVER_PORT);

                byte[] buffer = new byte[BUFFER_SIZE];
                IPEndPoint peer = new IPEndPoint(IPAddress.Any, 0);
                EndPoint peer_ref = (EndPoint)peer;

                bool stop = false;
                while (stop == false)
                {
                    int received_length = socket.ReceiveFrom(buffer, ref peer_ref);
                    string msg = Encoding.ASCII.GetString(buffer, 0, received_length);
                    peer = (IPEndPoint)peer_ref;
                    IPEndPoint local = (IPEndPoint)socket.LocalEndPoint;
                    Console.WriteLine("- message {0}B of {1}B received from {2}:{3} on port {4}", msg.Length, received_length, peer.Address, peer.Port, local.Port);
                    Console.WriteLine("|{0}|", msg);

                    if (msg.Equals("stop"))
                    {
                        // received message "stop" to stop the receiver
                        stop = true;
                    }
                }

                socket.Close();
                Console.WriteLine("- socket closed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("- {0}", ex.Message);
            }
        }
    }
}
