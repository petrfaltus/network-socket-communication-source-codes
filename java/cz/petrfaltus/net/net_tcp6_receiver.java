
package cz.petrfaltus.net;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

import java.net.InetAddress;
import java.net.ServerSocket;
import java.net.Socket;

import static java.lang.System.out;

public class net_tcp6_receiver {
    private static final int RECEIVER_PORT = 10000;
    private static final int RECEIVED_MESSAGES_MAX = 10;

    public static void main(String[] args) {
        out.println("TCP IPv6 stream socket receiver");

        try {
            ServerSocket socket = new ServerSocket(RECEIVER_PORT, RECEIVED_MESSAGES_MAX);
            out.println("- socket created, bound on port " + RECEIVER_PORT + " and is listening for max " + RECEIVED_MESSAGES_MAX + " messages");

            boolean stop = false;
            while (stop == false) {
                Socket msgsock = socket.accept();
                out.println("- socket accepted request");

                InetAddress peer = msgsock.getInetAddress();
                InetAddress local = msgsock.getLocalAddress();
                out.println("- peer connect from [" + peer.getHostAddress() + "]:" + msgsock.getPort() + " on [" + local.getHostAddress() + "]:" + msgsock.getLocalPort());

                InputStreamReader isr = new InputStreamReader(msgsock.getInputStream());
                BufferedReader br = new BufferedReader(isr);

                String msg = br.readLine();
                out.println("- message " + msg.length() + "B received");
                out.println("|" + msg + "|");

                if (msg.equals("stop")) {
                    // received message "stop" to stop the receiver
                    stop = true;
                }

                msgsock.close();
                out.println("- socket closed request");
            }

            socket.close();
            out.println("- socket closed");
        } catch (IOException e) {
            out.println("- " + e);
        }
    }
}
