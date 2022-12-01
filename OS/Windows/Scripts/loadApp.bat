Remove-Item -Path C:/tmp/cross_app.zip
curl -o C:/tmp/cross_app.zip https://github.com/Alex-knu/Cross_platform/archive/refs/heads/master.zip
mkdir C:/Cross_app
rmdir C:/Cross_app/src
mkdir C:/Cross_app/src
Expand-Archive -LiteralPath C:/tmp/cross_app.zip -DestinationPath  C:/Cross_app/src
rmdir C:/Cross_app/app