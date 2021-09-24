
package cz.petrfaltus.net;

import java.io.IOException;
import java.io.PrintStream;

import java.net.InetAddress;
import java.net.Socket;

import java.text.DateFormat;
import java.text.SimpleDateFormat;

import java.util.Date;

import static java.lang.System.out;

public class net_tcp6_sender {
    private static final String RECEIVER_ADDRESS = "::1";
    private static final int RECEIVER_PORT = 10000;

    public static void main(String[] args) {
        out.println("TCP IPv6 stream socket sender");

        try {
            Socket socket = new Socket(RECEIVER_ADDRESS, RECEIVER_PORT);
            out.println("- socket created for sending to [" + RECEIVER_ADDRESS + "]:" + RECEIVER_PORT);

            InetAddress peer = socket.getInetAddress();
            InetAddress local = socket.getLocalAddress();
            out.println("- for [" + peer.getHostAddress() + "]:" + socket.getPort() + " bound on [" + local.getHostAddress() + "]:" + socket.getLocalPort());

            PrintStream output_stream = new PrintStream(socket.getOutputStream());

            String msg;
            if (args.length > 0) {
                msg = args[0]; // message is the first parameter, for example "stop" to stop the receiver
            } else {
                Date now = new Date();
                DateFormat date_format = new SimpleDateFormat("d.M.yyyy 'in' H:mm:ss");

                msg = "This is Java message sent at " + date_format.format(now);
            }
            out.println("|" + msg + "|");

            output_stream.print(msg);
            out.println("- message " + msg.length() + "B sent");

            output_stream.close();
            socket.close();
            out.println("- socket closed");
        } catch (IOException e) {
            out.println("- " + e);
        }
    }
}
