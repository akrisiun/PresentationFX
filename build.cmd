
set msbuild="c:\Program Files\MSBuild\14.0\Bin\MSBuild.exe"
%msbuild% PresentationFx.sln /verbosity:m

set dir=%~dp0
rmdir /s/q %dir%\lib\en 
rmdir /s/q %dir%\lib\zh-Hant 
rmdir /s/q %dir%\lib\zh-Hans
rmdir /s/q %dir%\lib\ru 
rmdir /s/q %dir%\lib\ko 
rmdir /s/q %dir%\lib\ja 
rmdir /s/q %dir%\lib\it 
rmdir /s/q %dir%\lib\fr 
rmdir /s/q %dir%\lib\es 
rmdir /s/q %dir%\lib\en 
rmdir /s/q %dir%\lib\de 

@PAUSE