for /f "tokens=*" %%a in ('"ver"') do set VER=%%a
if %VER:~-9,3%==6.2 goto WIN8
if %VER:~-9,3%==6.3 goto WIN8
start "WebServer" "%cd%\IDWS_Notificatore.exe" "%cd%" 1308 "/Notificatore/" "Notificatore.aspx" 30 "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" ""
goto END
:WIN8
start "WebServer" "%cd%\IDWS8_Notificatore.exe" "%cd%" 1308 "/Notificatore/" "Notificatore.aspx" 30 "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" ""
:END
