@echo off
cls
dotnet restore
dotnet build "Surging.Core.Caching.csproj"  --configuration Release 
copy  bin\Release\netcoreapp2.1\Surging.Core.Caching.dll ..\..\..\applib\3rdlib\surging\/y
echo ִ�����
pause