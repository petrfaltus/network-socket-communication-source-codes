<?php

set_time_limit(0);

const RECEIVER_ADDRESS = "::0";
const RECEIVER_PORT = 10000;
const BUFFER_SIZE = 4096;

echo "UDP IPv6 datagram socket receiver".PHP_EOL;

$socket = @socket_create(AF_INET6, SOCK_DGRAM, SOL_UDP);
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
echo "- socket bound on [".RECEIVER_ADDRESS."]:".RECEIVER_PORT.PHP_EOL;

$stop = false;
while ($stop == false)
{
  $msg = "";
  $peer_address = "";
  $peer_port = 0;

  $received_length = @socket_recvfrom($socket, $msg, BUFFER_SIZE, 0, $peer_address, $peer_port);
  if ($received_length === false)
  {
    exit("- socket_recvfrom() failed: ".socket_strerror(socket_last_error($socket)).PHP_EOL);
  }
  echo "- message ".$received_length."B received from [".$peer_address."]:".$peer_port.PHP_EOL;
  echo "|".$msg."|".PHP_EOL;
      
  if ($msg == "stop")
  {
    // received message "stop" to stop the receiver
    $stop = true;
  }
}

socket_close($socket);
echo "- socket closed".PHP_EOL;

?>
