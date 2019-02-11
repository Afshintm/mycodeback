Echo Better to use MicroServices/build-all-db

REM dotnet ef migrations add ApplicationDatabase -c ApplicationDbContext -o Data/Migrations/ApplicationDatabase --startup-project ../Essence.Communication.Api

REM dotnet ef migrations script -c ApplicationDbContext -o Data/Migrations/ApplicationDatabase.sql --startup-project ../Essence.Communication.Api

REM dotnet ef database  update --context ApplicationDbContext --startup-project ../Essence.communication.api

