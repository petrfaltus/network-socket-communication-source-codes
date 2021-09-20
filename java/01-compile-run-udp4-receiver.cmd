@echo off

set CLASS=net_udp_receiver
set SOURCE=cz\petrfaltus\net
set PACKAGE=cz.petrfaltus.net

"%JAVA_HOME%\bin\javac" %SOURCE%\%CLASS%.java
"%JAVA_HOME%\bin\java" %PACKAGE%.%CLASS% %1
