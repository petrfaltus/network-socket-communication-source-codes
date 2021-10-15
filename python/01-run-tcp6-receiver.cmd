@echo off

set SRC=src

set PROJECT=net_tcp6_receiver
set SOURCE=%SRC%\%PROJECT%.py

"%PYTHON_HOME%\python.exe" %SOURCE% %1
