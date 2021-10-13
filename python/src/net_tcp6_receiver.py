import socket

RECEIVER_ADDRESS = "::1"
RECEIVER_PORT = 10000
RECEIVED_MESSAGES_MAX = 10
BUFFER_SIZE = 4096

print("TCP IPv6 stream socket receiver")

receivingSocket = socket.socket(family=socket.AF_INET6, type=socket.SOCK_STREAM)
print("- socket created")

receiver = (RECEIVER_ADDRESS, RECEIVER_PORT);

receivingSocket.bind(receiver)
print("- socket bound on [" + RECEIVER_ADDRESS + "]:" + str(RECEIVER_PORT))

receivingSocket.listen(RECEIVED_MESSAGES_MAX)
print("- socket is listening for max " + str(RECEIVED_MESSAGES_MAX) + " messages")

stop = False
while (stop == False):
    (msgsock, peer) = receivingSocket.accept()
    print("- socket accepted request")

    (peer_address, peer_port, peer_object3, peer_object4) = peer
    (local_address, local_port, local_object3, local_object4) = msgsock.getsockname()
    print("- peer connect from [" + peer_address + "]:" + str(peer_port) + " on [" + local_address + "]:" + str(local_port))

    buffer = msgsock.recv(BUFFER_SIZE)
    received_length = len(buffer)
    msg = buffer.decode()
    print("- message " + str(received_length) + "B received")
    print("|" + msg + "|")

    if msg == "stop":
        stop = True

    msgsock.close()
    print("- socket closed request")

receivingSocket.close()
print("- socket closed")
