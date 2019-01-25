cd ./MyIdentity.Migrations
dotnet ef database  update -c ApplicationIdentityDbContext --startup-project ../MyIdentity.Api/
cd ../Identity.Management.Api
dotnet ef database update -c PersistedGrantDbContext
dotnet ef database update -c ConfigurationDbContext
dotnet run /seed
