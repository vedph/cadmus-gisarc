@echo off
echo BUILD Cadmus GISARC Packages
del .\Cadmus.Gisarc.Parts\bin\Debug\*.snupkg
del .\Cadmus.Gisarc.Parts\bin\Debug\*.nupkg

del .\Cadmus.Gisarc.Services\bin\Debug\*.snupkg
del .\Cadmus.Gisarc.Services\bin\Debug\*.nupkg

del .\Cadmus.Seed.Gisarc.Parts\bin\Debug\*.snupkg
del .\Cadmus.Seed.Gisarc.Parts\bin\Debug\*.nupkg

cd .\Cadmus.Gisarc.Parts
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

cd .\Cadmus.Gisarc.Services
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

cd .\Cadmus.Seed.Gisarc.Parts
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

pause
