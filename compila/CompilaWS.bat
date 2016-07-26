rd /s /q .\deployws

%WinDir%\Microsoft.NET\Framework\v4.0.30319\aspnet_compiler.exe -v /csws -p ..\output\csws  -u -f .\deployws -fixednames

rd /s /q .\deployws\logs
rd /s /q .\deployws\temp
rd /s /q .\deployws\dttimg

del .\deployws\qhel*.gif
del .\deployws\qhel*.jpg
del .\deployws\precomp*.config
del .\deployws\*.doc
del .\deployws\*.sln

move .\deploy\web.config .\deploy\web.config.standard

move .\deployws\calpopup.htm .\deployws\calpopup.htm.standard
move .\deployws\delaydlg.htm .\deployws\delaydlg.htm.standard
move .\deployws\qhelp.htm .\deployws\qhelp.htm.standard

del .\deployws\*.htm

move .\deployws\calpopup.htm.standard .\deployws\calpopup.htm
move .\deployws\delaydlg.htm.standard .\deployws\delaydlg.htm
move .\deployws\qhelp.htm.standard .\deployws\qhelp.htm

del .\deployws\*.exe
rem del .\deployws\*.dll
del .\deployws\*.bat

del .\deployws\IDWS.dll
del .\deployws\Intero*.*

del deployws.zip

"%ProgramFiles%\7-zip\7z.exe" a -tzip -r "deployws.zip" ".\deployws\*.*"


pause



