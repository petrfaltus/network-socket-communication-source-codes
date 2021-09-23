using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace NetUDP6receiver
{
    public class Program
    {
        private static readonly int RECEIVER_PORT = 10000;
        private static readonly int BUFFER_SIZE = 4096;

        public static void Main(string[] args)
        {
            Console.WriteLine("UDP IPv6 datagram socket receiver");

            try
            {
                Socket socket = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
                Console.WriteLine("- socket created");

                IPEndPoint receiver = new IPEndPoint(IPAddress.IPv6Any, RECEIVER_PORT);

                socket.Bind(receiver);
                Console.WriteLine("- socket bound on port {0}", RECEIVER_PORT);

                byte[] buffer = new byte[BUFFER_SIZE];
                IPEndPoint peer = new IPEndPoint(IPAddress.IPv6Any, 0);
                EndPoint peer_ref = (EndPoint)peer;

                bool stop = false;
                while (stop == false)
                {
                    int received_length = socket.ReceiveFrom(buffer, ref peer_ref);
                    string msg = Encoding.ASCII.GetString(buffer, 0, received_length);
                    peer = (IPEndPoint)peer_ref;
                    Console.WriteLine("- message {0}B of {1}B received from {2}:{3}", msg.Length, received_length, peer.Address, peer.Port);
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
