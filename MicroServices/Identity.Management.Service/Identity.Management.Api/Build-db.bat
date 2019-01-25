
rmdir /S /Q Data\Migrations

REM If we want to do the application Migration in the Identity management api which should not be the case
REM dotnet ef migrations add InitialCreate  -c ApplicationIdentityDbContext  -o Data/Migrations/ApplicationIdentityDb
REM dotnet ef migrations script -c ApplicationIdentityDbContext  -o Data/Migrations/ApplicationIdentityDb.sql
REM dotnet ef database  update -c ApplicationIdentityDbContext 



dotnet ef migrations add Grants -c PersistedGrantDbContext -o Data/Migrations/PersistedGrantDb


dotnet ef migrations script -c PersistedGrantDbContext -o Data/Migrations/PersistedGrantDb.sql


dotnet ef database update -c PersistedGrantDbContext



dotnet ef migrations add Config -c ConfigurationDbContext -o Data/Migrations/ConfigurationDb

dotnet ef migrations script -c ConfigurationDbContext -o Data/Migrations/ConfigurationDb.sql

dotnet ef database update -c ConfigurationDbContext 



dotnet run /seed
