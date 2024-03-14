@echo off
@oakey.exe
@if %ERRORLEVEL% EQU 1 (
    @echo %COMPUTERNAME% : has an Original Microsoft Windows Key in bios
) else if %ERRORLEVEL% EQU 0 (
    @echo %COMPUTERNAME% : no Orirignal Microsoft Windows Key Found in bios
)
