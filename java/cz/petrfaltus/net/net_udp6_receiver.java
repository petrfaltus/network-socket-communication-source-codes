
package cz.petrfaltus.net;

import java.io.IOException;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

import static java.lang.System.out;

public class net_udp6_receiver {
    private static final String RECEIVER_ADDRESS = "::1";
    private static final int RECEIVER_PORT = 10000;
    private static final int BUFFER_SIZE = 4096;

    public static void main(String[] args) {
        out.println("UDP IPv6 datagram socket receiver");

        try {
            InetAddress receiver_address = InetAddress.getByName(RECEIVER_ADDRESS);

            DatagramSocket socket = new DatagramSocket(RECEIVER_PORT, receiver_address);
            out.println("- socket created and bound on " + RECEIVER_ADDRESS + ":" + RECEIVER_PORT);

            byte[] buffer = new byte[BUFFER_SIZE];

            boolean stop = false;
            while (stop == false) {
                DatagramPacket packet = new DatagramPacket(buffer, buffer.length);

                socket.receive(packet);
                String msg = new String(packet.getData(), 0, packet.getLength());
                InetAddress peer = packet.getAddress();
                out.println("- message " + msg.length() + "B of " + packet.getLength() + "B received from " + peer.getHostAddress() + ":" + packet.getPort());
                out.println("|" + msg + "|");

                if (msg.equals("stop")) {
                    // received message "stop" to stop the receiver
                    stop = true;
                }
            }

            socket.close();
            out.println("- socket closed");
        } catch (IOException e) {
            out.println("- " + e);
        }
    }
}
