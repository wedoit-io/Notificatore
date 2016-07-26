@echo off 


rd /s /q .\deploy

%WinDir%\Microsoft.NET\Framework\v4.0.30319\aspnet_compiler.exe -v /csharp -p ..\output\csharp -u -f .\deploy -fixednames

rd /s /q .\deploy\logs
rd /s /q .\deploy\temp
rd /s /q .\deploy\dttimg
rd /s /q .\deploy\fckeditor

del .\deploy\qhel*.gif
del .\deploy\qhel*.jpg
del .\deploy\precomp*.config
del .\deploy\*.doc
del .\deploy\*.sln

move .\deploy\web.config .\deploy\web.config.standard

move .\deploy\calpopup.htm .\deploy\calpopup.htm.standard
move .\deploy\delaydlg.htm .\deploy\delaydlg.htm.standard
move .\deploy\qhelp.htm .\deploy\qhelp.htm.standard

del .\deploy\*.htm

move .\deploy\calpopup.htm.standard .\deploy\calpopup.htm
move .\deploy\delaydlg.htm.standard .\deploy\delaydlg.htm
move .\deploy\qhelp.htm.standard .\deploy\qhelp.htm


del .\deploy\*.exe
del .\deploy\*.dll
del .\deploy\*.bat

del cim_deploy.zip


copy ..\output\csharp\Desktop_sm.htm .\deploy
copy ..\output\csharp\Global.asax .\deploy
copy ..\output\csharp\Desktop.htm .\deploy

rem copy ..\..\crm.idp .

rem zip -r cim_deploy.zip deploy crm.idp

rem zip -r cim_deploy.zip deploy

"%ProgramFiles%\7-zip\7z.exe" a -tzip -r "deploy.zip" ".\deploy\*.*"
rem "%ProgramFiles%\7-zip\7z.exe" a -t7z -r "cim_deploy.zip" ".\deploy\*.*"

pause






