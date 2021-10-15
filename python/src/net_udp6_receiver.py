import socket

RECEIVER_ADDRESS = "::0"
RECEIVER_PORT = 10000
BUFFER_SIZE = 4096

print("UDP IPv6 datagram socket receiver")

receivingSocket = socket.socket(family=socket.AF_INET6, type=socket.SOCK_DGRAM)
print("- socket created")

receiver = (RECEIVER_ADDRESS, RECEIVER_PORT);

receivingSocket.bind(receiver)
print("- socket bound on [" + RECEIVER_ADDRESS + "]:" + str(RECEIVER_PORT))

stop = False
while (stop == False):
    (buffer, peer) = receivingSocket.recvfrom(BUFFER_SIZE)
    received_length = len(buffer)
    msg = buffer.decode()
    (peer_address, peer_port, peer_object3, peer_object4) = peer
    print("- message " + str(received_length) + "B received from [" + peer_address + "]:" + str(peer_port) + " on port " + str(RECEIVER_PORT))
    print("|" + msg + "|")

    if msg == "stop":
        stop = True

receivingSocket.close()
print("- socket closed")
