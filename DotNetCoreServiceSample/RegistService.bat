@echo off
cd %~dp0
sc create DotNetCoreService binPath="%CD%\bin\Release\netcoreapp2.2\win-x64\DotNetCoreServiceSample.exe"
sc start DotNetCoreService

:: çÌèúóp
:: sc stop DotNetCoreService
:: sc delete DotNetCoreService binPath="%CD%\bin\Release\netcoreapp2.2\win-x64\DotNetCoreServiceSample.exe"
