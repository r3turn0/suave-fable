@echo off
cls

pushd client
call build.cmd
popd

pushd server
call build.cmd
popd