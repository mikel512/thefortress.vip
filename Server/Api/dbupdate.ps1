dotnet ef dbcontext scaffold `
 Name="DbConnection" `
 Microsoft.EntityFrameworkCore.SqlServer -o Models -f --verbose  --context-dir Data --context TheFortressContext
 Set-Location ..\..\NTypewriterCLI\NTypeWriterCli\
 dotnet run -s ..\..\Server\TheFortress.sln -verbose
 Set-Location ..\..\Server\Api\
