@echo off
cls
dotnet restore
dotnet build "Surging.Core.Log4net.csproj"  --configuration Release 
copy  bin\Release\netcoreapp2.1\Surging.Core.Log4net.dll ..\..\..\applib\3rdlib\surging\/y
echo ִ�����
pause