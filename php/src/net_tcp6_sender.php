<?php

set_time_limit(0);

const RECEIVER_ADDRESS = "::1";
const RECEIVER_PORT = 10000;

echo "TCP IPv6 stream socket sender".PHP_EOL;

$socket = @socket_create(AF_INET6, SOCK_STREAM, SOL_TCP);
if ($socket === false)
{
  exit("- socket_create() failed: ".socket_strerror(socket_last_error()).PHP_EOL);
}
echo "- socket created".PHP_EOL;

$result = @socket_connect($socket, RECEIVER_ADDRESS, RECEIVER_PORT);
if ($result === false)
{
  exit("- socket_connect() failed: ".socket_strerror(socket_last_error($socket)).PHP_EOL);
}
echo "- connected to [".RECEIVER_ADDRESS."]:".RECEIVER_PORT.PHP_EOL;

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
$sent_length = @socket_send($socket, $msg, $msg_length, 0);
if ($sent_length === false)
{
  exit("- socket_send() failed: ".socket_strerror(socket_last_error($socket)).PHP_EOL);
}
echo "- message ".$sent_length."B of ".$msg_length."B sent".PHP_EOL;

socket_close($socket);
echo "- socket closed".PHP_EOL;

?>
