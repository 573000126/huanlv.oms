@echo off
cls
dotnet restore
dotnet build "Surging.Core.Common.csproj"  --configuration Release 
copy  bin\Release\netcoreapp2.1\Surging.Core.Common.dll ..\..\..\applib\3rdlib\surging\/y
echo ִ�����
pause