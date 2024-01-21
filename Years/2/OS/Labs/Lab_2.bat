@echo off
title Lab_2
cls

set /p word=Enter the search word in *.txt files of disk C:\ 
echo working. . .
>ZVIT.txt findstr /S /M "%word%" "C:\*.txt"

start ZVIT.txt
pause