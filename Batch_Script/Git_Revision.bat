echo off

set mypath=%cd%
set drive_path=%mypath:~0,1%

if "%drive_path%"=="C" (
    hostname
    cd %mypath% && git rev-list --count HEAD
) else (
    hostname
    cd /d %mypath% && git rev-list --count HEAD
)

