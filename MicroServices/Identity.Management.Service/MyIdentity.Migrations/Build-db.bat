rmdir /S /Q Data\Migrations

dotnet ef migrations add InitialCreate  -c ApplicationIdentityDbContext  --startup-project ../MyIdentity.Api/ -o Data/Migrations/ApplicationIdentityDb

dotnet ef migrations script -c ApplicationIdentityDbContext --startup-project ../MyIdentity.Api/ -o Data/Migrations/ApplicationIdentityDb.sql

dotnet ef database  update -c ApplicationIdentityDbContext --startup-project ../MyIdentity.Api/


