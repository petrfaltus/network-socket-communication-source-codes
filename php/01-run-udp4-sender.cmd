@echo off

set SRC=src

set PROJECT=net_udp_sender
set SOURCE=%SRC%\%PROJECT%.php

"%PHP_HOME%\php.exe" %SOURCE% %1
