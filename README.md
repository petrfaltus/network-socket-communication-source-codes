# Network socket communication source codes
Small example console source codes for a network TCP and UDP socket communication over IPv4 and IPv6. For every type of communication there is the sender and the receiver for one text message over the network localhost interface preset.

The receiver must be called first, then the sender. The sender can be called more times for the same receiver. If you want transmitt own text message instead of the default, add it as the first parameter to the command line with the sender calling. Finally for stopping the receiver there must be with the sender calling the `stop` parameter entered.

## Running under Windows
1. clone this repository to your computer
2. compile and run the example **Java** code

### 1. Cloning to your computer
- install [GIT] on your computer
- clone this repository to your computer by the GIT command
  `git clone https://github.com/petrfaltus/network-socket-communication-source-codes.git`

### 2. The Java client source code
- install [Java JDK] on your computer
- set the OS environment `%JAVA_HOME%` variable (must exist `"%JAVA_HOME%\bin\java.exe"`)

The subdirectory `java` contains prepared Windows batches:
- `01-compile-run-tcp4-receiver.cmd` - compiles and runs the Java CLASS for TCP IPv4 receiver
- `01-compile-run-tcp4-sender.cmd` - compiles and runs the Java CLASS for TCP IPv4 sender
- `01-compile-run-tcp6-receiver.cmd` - compiles and runs the Java CLASS for TCP IPv6 receiver 
- `01-compile-run-tcp6-sender.cmd` - compiles and runs the Java CLASS for TCP IPv6 sender
- `01-compile-run-udp4-receiver.cmd` - compiles and runs the Java CLASS for UDP IPv4 receiver
- `01-compile-run-udp4-sender.cmd` - compiles and runs the Java CLASS for UDP IPv4 sender
- `01-compile-run-udp6-receiver.cmd` - compiles and runs the Java CLASS for UDP IPv6 receiver
- `01-compile-run-udp6-sender.cmd` - compiles and runs the Java CLASS for UDP IPv6 sender
- `02-clean.cmd` - removes all CLASS files

## Versions
Now in September 2021 I have the computer with **Windows 10 Pro 64bit**, **12GB RAM** and available **50GB free HDD space**

| Tool | Version | Setting |
| ------ | ------ | ------ |
| [GIT] | 2.30.0.windows.2 | |
| [Java JDK] | 15.0.2 | Java(TM) SE Runtime Environment (build 15.0.2+7-27) |

## To do (my plans to the future)

[GIT]: <https://git-scm.com/>
[Java JDK]: <https://www.oracle.com/java/technologies/javase-downloads.html>
