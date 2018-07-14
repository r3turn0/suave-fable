@echo off
call yarn.cmd
call restore.cmd
echo building bundle.js from client project
dotnet fable yarn-run build