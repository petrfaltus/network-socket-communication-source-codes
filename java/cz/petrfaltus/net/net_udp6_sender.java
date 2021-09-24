
package cz.petrfaltus.net;

import java.io.IOException;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

import java.text.DateFormat;
import java.text.SimpleDateFormat;

import java.util.Date;

import static java.lang.System.out;

public class net_udp6_sender {
    private static final String RECEIVER_ADDRESS = "::1";
    private static final int RECEIVER_PORT = 10000;

    public static void main(String[] args) {
        out.println("UDP IPv6 datagram socket sender");

        try {
            DatagramSocket socket = new DatagramSocket();
            out.println("- socket created");

            String msg;
            if (args.length > 0) {
                msg = args[0]; // message is the first parameter, for example "stop" to stop the receiver
            } else {
                Date now = new Date();
                DateFormat date_format = new SimpleDateFormat("d.M.yyyy 'in' H:mm:ss");

                msg = "This is Java message sent at " + date_format.format(now);
            }
            out.println("|" + msg + "|");

            byte[] buffer = msg.getBytes();
            InetAddress receiver_address = InetAddress.getByName(RECEIVER_ADDRESS);
            DatagramPacket packet = new DatagramPacket(buffer, buffer.length, receiver_address, RECEIVER_PORT);

            InetAddress peer = packet.getAddress();
            out.println("- for [" + peer.getHostAddress() + "]:" + packet.getPort() + " bound on port " + socket.getLocalPort());

            socket.send(packet);
            out.println("- message " + buffer.length + "B of " + msg.length() + "B sent to [" + RECEIVER_ADDRESS + "]:" + RECEIVER_PORT);

            socket.close();
            out.println("- socket closed");
        } catch (IOException e) {
            out.println("- " + e);
        }
    }
}
