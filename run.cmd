@echo off
cls

pushd client
call build.cmd
popd

pushd server
call run.cmd
popd