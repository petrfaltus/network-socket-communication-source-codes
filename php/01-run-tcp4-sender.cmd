@echo off

set SRC=src

set PROJECT=net_tcp_sender
set SOURCE=%SRC%\%PROJECT%.php

"%PHP_HOME%\php.exe" %SOURCE% %1
