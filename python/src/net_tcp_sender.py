import socket
import sys
from datetime import datetime

RECEIVER_ADDRESS = "127.0.0.1";
RECEIVER_PORT = 10000;

print("TCP IPv4 stream socket sender")

sendingSocket = socket.socket(family=socket.AF_INET, type=socket.SOCK_STREAM)
print("- socket created")

receiver_address = (RECEIVER_ADDRESS, RECEIVER_PORT)

sendingSocket.connect(receiver_address)
print("- connected to " + RECEIVER_ADDRESS + ":" + str(RECEIVER_PORT))

(local_address, local_port) = sendingSocket.getsockname()
print("- for " + RECEIVER_ADDRESS + ":" + str(RECEIVER_PORT) + " bound on " + local_address + ":" + str(local_port))

if len(sys.argv) > 1:
    msg = sys.argv[1] # message is the first parameter, for example "stop" to stop the receiver
else:
    now = datetime.now()
    msg = "This is Python message sent at " + now.strftime("%d.%m.%Y") + " in " + now.strftime("%H:%M:%S")
print("|" + msg + "|")

buffer = str.encode(msg)

msg_length = len(msg)
sendingSocket.send(buffer)
print("- message " + str(msg_length) + "B sent")

sendingSocket.close();
print("- socket closed")
