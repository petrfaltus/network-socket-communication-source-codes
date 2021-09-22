using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace NetTCPsender
{
    public class Program
    {
        private static readonly string RECEIVER_ADDRESS = "127.0.0.1";
        private static readonly int RECEIVER_PORT = 10000;

        public static void Main(string[] args)
        {
            Console.WriteLine("TCP IPv4 stream socket sender");

            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Console.WriteLine("- socket created");

                IPAddress receiver_address = IPAddress.Parse(RECEIVER_ADDRESS);
                IPEndPoint receiver = new IPEndPoint(receiver_address, RECEIVER_PORT);

                socket.Connect(receiver);
                Console.WriteLine("- connected to {0}:{1}", receiver_address, RECEIVER_PORT);

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

                int sent_length = socket.Send(buffer);
                Console.WriteLine("- message {0}B of {1}B sent", sent_length, msg.Length);

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
