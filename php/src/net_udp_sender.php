<?php

set_time_limit(0);

const RECEIVER_ADDRESS = "127.0.0.1";
const RECEIVER_PORT = 10000;

echo "UDP IPv4 datagram socket sender".PHP_EOL;

$socket = @socket_create(AF_INET, SOCK_DGRAM, SOL_UDP);
if ($socket === false)
{
  exit("- socket_create() failed: ".socket_strerror(socket_last_error()).PHP_EOL);
}
echo "- socket created".PHP_EOL;

if (isset($argv[1]))
{
  $msg = $argv[1]; // message is the first parameter, for example "stop" to stop the receiver
}
else
{
  $msg = "This is PHP message sent at ".date("j.n.Y")." in ".date("G:i:s");
}
echo "|".$msg."|".PHP_EOL;

$msg_length = strlen($msg); 
socket_sendto($socket, $msg, $msg_length, 0, RECEIVER_ADDRESS, RECEIVER_PORT);
echo "- message ".$msg_length."B sent to ".RECEIVER_ADDRESS.":".RECEIVER_PORT.PHP_EOL;

socket_close($socket);
echo "- socket closed".PHP_EOL;

?>
