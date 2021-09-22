@echo off

set CLASS=net_tcp6_sender
set SOURCE=cz\petrfaltus\net
set PACKAGE=cz.petrfaltus.net

"%JAVA_HOME%\bin\javac" %SOURCE%\%CLASS%.java
"%JAVA_HOME%\bin\java" %PACKAGE%.%CLASS% %1
