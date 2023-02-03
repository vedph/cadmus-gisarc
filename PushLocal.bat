@echo off
echo PRESS ANY KEY TO INSTALL TO LOCAL NUGET FEED
echo Remember to generate the up-to-date package.
c:\exe\nuget add .\Cadmus.Gisarc.Parts\bin\Debug\Cadmus.Gisarc.Parts.2.0.0.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Gisarc.Services\bin\Debug\Cadmus.Gisarc.Services.2.0.0.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Seed.Gisarc.Parts\bin\Debug\Cadmus.Seed.Gisarc.Parts.2.0.0.nupkg -source C:\Projects\_NuGet
pause
