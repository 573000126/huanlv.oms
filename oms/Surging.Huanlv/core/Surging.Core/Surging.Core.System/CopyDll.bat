@echo off
cls
dotnet restore
dotnet build "Surging.Core.System.csproj"  --configuration Release 
copy  bin\Release\netcoreapp2.1\Surging.Core.System.dll ..\..\..\applib\3rdlib\surging\/y
echo ִ�����
pause