using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace NetTCPreceiver
{
    public class Program
    {
        private static readonly string RECEIVER_ADDRESS = "127.0.0.1";
        private static readonly int RECEIVER_PORT = 10000;
        private static readonly int RECEIVED_MESSAGES_MAX = 10;
        private static readonly int BUFFER_SIZE = 4096;

        public static void Main(string[] args)
        {
            Console.WriteLine("TCP IPv4 stream socket receiver");

            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Console.WriteLine("- socket created");

                IPAddress receiver_address = IPAddress.Parse(RECEIVER_ADDRESS);
                IPEndPoint receiver = new IPEndPoint(receiver_address, RECEIVER_PORT);

                socket.Bind(receiver);
                Console.WriteLine("- socket bound on {0}:{1}", receiver_address, RECEIVER_PORT);

                socket.Listen(RECEIVED_MESSAGES_MAX);
                Console.WriteLine("- socket is listening for max {0} messages", RECEIVED_MESSAGES_MAX);

                bool stop = false;
                while (stop == false)
                {
                    Socket msgsock = socket.Accept();
                    Console.WriteLine("- socket accepted request");

                    IPEndPoint peer = (IPEndPoint)msgsock.RemoteEndPoint;
                    Console.WriteLine("- peer connect from {0}:{1}", peer.Address, peer.Port);

                    byte[] buffer = new byte[BUFFER_SIZE];
                    int received_length = msgsock.Receive(buffer);
                    string msg = Encoding.ASCII.GetString(buffer, 0, received_length);
                    Console.WriteLine("- message {0}B of {1}B received", msg.Length, received_length);
                    Console.WriteLine("|{0}|", msg);

                    if (msg.Equals("stop"))
                    {
                        // received message "stop" to stop the receiver
                        stop = true;
                    }

                    msgsock.Close();
                    Console.WriteLine("- socket closed request");
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