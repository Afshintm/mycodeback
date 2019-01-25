This command needs to be run within the main folder of this project 
add initial migration    
   
dotnet ef migrations add InitialCreate  -c ApplicationIdentityDbContext  --startup-project ../MyIdentity.Api/ -o Data/Migrations/ApplicationIdentityDb
but I removed it from build-db.bat because I have run it once and changed the database table names 

with this command we can update database from initialCreate which is ceating db

dotnet ef database  update -c ApplicationIdentityDbContext --startup-project ../MyIdentity.Api/
