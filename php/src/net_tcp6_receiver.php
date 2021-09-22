<?php

set_time_limit(0);

const RECEIVER_ADDRESS = "::1";
const RECEIVER_PORT = 10000;
const RECEIVED_MESSAGES_MAX = 10;
const BUFFER_SIZE = 4096;

echo "TCP IPv6 stream socket receiver".PHP_EOL;

$socket = @socket_create(AF_INET6, SOCK_STREAM, SOL_TCP);
if ($socket === false)
{
  exit("- socket_create() failed: ".socket_strerror(socket_last_error()).PHP_EOL);
}
echo "- socket created".PHP_EOL;

$bound = @socket_bind($socket, RECEIVER_ADDRESS, RECEIVER_PORT);
if ($bound === false)
{
  exit("- socket_bind() failed: ".socket_strerror(socket_last_error($socket)).PHP_EOL); 
}
echo "- socket bound on ".RECEIVER_ADDRESS.":".RECEIVER_PORT.PHP_EOL;

$listening = @socket_listen($socket, RECEIVED_MESSAGES_MAX);
if ($listening === false)
{
  exit("- socket_listen() failed: ".socket_strerror(socket_last_error($socket)).PHP_EOL); 
}
echo "- socket is listening for max ".RECEIVED_MESSAGES_MAX." messages".PHP_EOL;

$stop = false;
while ($stop == false)
{
  $msgsock = @socket_accept($socket);
  if ($msgsock === false)
  {
    exit("- socket_accept() failed: ".socket_strerror(socket_last_error($socket)).PHP_EOL);
  }
  echo "- socket accepted request".PHP_EOL;

  $peer_address = "";
  $peer_port = 0;

  $peer = @socket_getpeername($msgsock, $peer_address, $peer_port);
  if ($peer === false)
  {
    exit("- socket_getpeername() failed: ".socket_strerror(socket_last_error($msgsock)).PHP_EOL);
  }
  echo "- peer connect from ".$peer_address.":".$peer_port.PHP_EOL;

  $msg = "";

  $received_length = @socket_recv($msgsock, $msg, BUFFER_SIZE, 0);
  if ($received_length === false)
  {
    exit("- socket_recv() failed: ".socket_strerror(socket_last_error($msgsock)).PHP_EOL);
  }
  echo "- message ".$received_length."B received".PHP_EOL;
  echo "|".$msg."|".PHP_EOL;
      
  if ($msg == "stop")
  {
    // received message "stop" to stop the receiver
    $stop = true;
  }
   
  socket_close($msgsock); 
  echo "- socket closed request".PHP_EOL;
}

socket_close($socket);
echo "- socket closed".PHP_EOL;

?>
