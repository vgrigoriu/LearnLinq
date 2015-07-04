@echo off
%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe LearnLinq.sln /verbosity:quiet /nologo
packages\Fixie.1.0.0.15\lib\net45\Fixie.Console.exe bin\Debug\LearnLinq.dll
