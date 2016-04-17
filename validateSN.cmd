@ECHO run as Admin

set dir=%~dp0lib
c:\bin\net46\sn.exe -Vr %dir%\PresentationFramework.dll

@PAUSE