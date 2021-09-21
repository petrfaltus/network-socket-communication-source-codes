@echo off

set SRC=src
set OUT=bin

set PROJECT=NetTCP6receiver
set SOURCE=%SRC%\%PROJECT%.cs
set EXECUTABLE=%OUT%\%PROJECT%.exe
set ICON=ico\NetCommunication.ico
set DOTNET_HOME=C:\WINDOWS\Microsoft.NET\Framework64\v4.0.30319

mkdir %OUT%
"%DOTNET_HOME%\csc.exe" /win32icon:%ICON% /out:%EXECUTABLE% %SOURCE%

%EXECUTABLE% %1
