dotnet ef migrations add ApplicationIdentity  -c ApplicationIdentityDbContext  -o Data/Migrations/ApplicationIdentityDb

dotnet ef migrations script -c ApplicationIdentityDbContext -o Data/Migrations/ApplicationIdentityDb.sql

dotnet ef database  update -c ApplicationIdentityDbContext 


REM dotnet ef migrations add Grants -c PersistedGrantDbContext -o Data/Migrations/PersistedGrantDb

REM dotnet ef migrations script -c PersistedGrantDbContext -o Data/Migrations/PersistedGrantDb.sql

REM dotnet ef database update -c PersistedGrantDbContext


REM dotnet ef migrations add Config -c ConfigurationDbContext -o Data/Migrations/ConfigurationDb

REM dotnet ef migrations script -c ConfigurationDbContext -o Data/Migrations/ConfigurationDb.sql

REM dotnet ef database update -c ConfigurationDbContext

dotnet run /seed
