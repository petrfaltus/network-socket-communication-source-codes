using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace NetUDP6sender
{
    public class Program
    {
        private static readonly string RECEIVER_ADDRESS = "::1";
        private static readonly int RECEIVER_PORT = 10000;

        public static void Main(string[] args)
        {
            Console.WriteLine("UDP IPv6 datagram socket sender");

            try
            {
                Socket socket = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
                Console.WriteLine("- socket created");

                string msg;
                if (args.Length > 0)
                    msg = args[0]; // message is the first parameter, for example "stop" to stop the receiver
                else
                {
                    DateTime now = DateTime.Now;
                    msg = string.Format("This is C# message sent at {0} in {1}", now.ToString("d.M.yyyy"), now.ToString("H:mm:ss"));
                }
                Console.WriteLine("|{0}|", msg);

                byte[] buffer = Encoding.ASCII.GetBytes(msg);
                IPAddress receiver_address = IPAddress.Parse(RECEIVER_ADDRESS);
                IPEndPoint receiver = new IPEndPoint(receiver_address, RECEIVER_PORT);

                int sent_length = socket.SendTo(buffer, receiver);
                IPEndPoint local = (IPEndPoint)socket.LocalEndPoint;
                Console.WriteLine("- message {0}B of {1}B sent to [{2}]:{3} on port {4}", sent_length, msg.Length, receiver_address, RECEIVER_PORT, local.Port);

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
