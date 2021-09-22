@echo off

set SRC=src

set PROJECT=net_tcp6_receiver
set SOURCE=%SRC%\%PROJECT%.php

"%PHP_HOME%\php.exe" %SOURCE% %1
