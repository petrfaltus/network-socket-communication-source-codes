@echo off

set SRC=src

set PROJECT=net_tcp_sender
set SOURCE=%SRC%\%PROJECT%.py

"%PYTHON_HOME%\python.exe" %SOURCE% %1
