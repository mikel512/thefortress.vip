dotnet ef dbcontext scaffold `
 Name="DbConnection" `
 Microsoft.EntityFrameworkCore.SqlServer -o Models -f --verbose  --context-dir Data --context TheFortressContext
 Set-Location ..\NTypewriterCLI\NTypeWriterCli\
 dotnet run -s ..\..\TheFortress.API\TheFortress.API.sln
 Set-Location ..\..\TheFortress.API\
