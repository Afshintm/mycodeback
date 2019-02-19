Echo User $Env:ASPNETCORE_ENVIRONMENT = "Test" in powershell to set the environment variable 

cd Essence.Communication.Service/Essence.Communication.DbContexts
REM dotnet ef migrations add ApplicationDatabase -c ApplicationDbContext -o Data/Migrations/ApplicationDatabase --startup-project ../Essence.Communication.Api

REM dotnet ef migrations script -c ApplicationDbContext -o Data/Migrations/ApplicationDatabase.sql --startup-project ../Essence.Communication.Api

dotnet ef database  update --context ApplicationDbContext --startup-project ../Essence.communication.api


cd ../../Identity.Management.Service/Identity.Management.Api

REM dotnet ef migrations add Grants -c PersistedGrantDbContext -o Data/Migrations/PersistedGrantDb

REM dotnet ef migrations script -c PersistedGrantDbContext -o Data/Migrations/PersistedGrantDb.sql

dotnet ef database update -c PersistedGrantDbContext


REM dotnet ef migrations add Config -c ConfigurationDbContext -o Data/Migrations/ConfigurationDb

REM dotnet ef migrations script -c ConfigurationDbContext -o Data/Migrations/ConfigurationDb.sql

dotnet ef database update -c ConfigurationDbContext

dotnet run /seed

cd ../../Essence.Communication.Service/Essence.Communication.DbContexts
REM dotnet ef migrations add ApplicationDatabase -c ApplicationDbContext -o Data/Migrations/ApplicationDatabase --startup-project ../Essence.Communication.Api

REM dotnet ef migrations script -c ApplicationDbContext -o Data/Migrations/ApplicationDatabase.sql --startup-project ../Essence.Communication.Api

dotnet ef database  update --context ApplicationDbContext --startup-project ../Essence.communication.api

