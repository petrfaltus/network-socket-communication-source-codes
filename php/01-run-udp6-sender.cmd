@echo off

set SRC=src

set PROJECT=net_udp6_sender
set SOURCE=%SRC%\%PROJECT%.php

"%PHP_HOME%\php.exe" %SOURCE% %1
