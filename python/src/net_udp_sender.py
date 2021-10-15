import socket
import sys
from datetime import datetime

RECEIVER_ADDRESS = "127.0.0.1";
RECEIVER_PORT = 10000;

print("UDP IPv4 datagram socket sender")

sendingSocket = socket.socket(family=socket.AF_INET, type=socket.SOCK_DGRAM)
print("- socket created")

if len(sys.argv) > 1:
    msg = sys.argv[1] # message is the first parameter, for example "stop" to stop the receiver
else:
    now = datetime.now()
    msg = "This is Python message sent at " + now.strftime("%d.%m.%Y") + " in " + now.strftime("%H:%M:%S")
print("|" + msg + "|")

buffer = str.encode(msg)
receiver_address = (RECEIVER_ADDRESS, RECEIVER_PORT)

msg_length = len(msg)
sendingSocket.sendto(buffer, receiver_address)

(local_address, local_port) = sendingSocket.getsockname()
print("- message " + str(msg_length) + "B sent to " + RECEIVER_ADDRESS + ":" + str(RECEIVER_PORT) + " on port " + str(local_port))

sendingSocket.close();
print("- socket closed")
