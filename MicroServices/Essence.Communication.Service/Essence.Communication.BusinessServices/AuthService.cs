using Essence.Communication.DbContexts;
using Essence.Communication.Models;
using Essence.Communication.Models.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Essence.Communication.BusinessServices
{
    public interface IAuthService
    {
        //ApplicationUser CreateUser(string username);
        //bool Login(string userName, string password);
        //IEnumerable<string> GetUsers();
    }
    public class AuthService : IAuthService
    {
        //IdentityDbContext _identityDbContext;
        public AuthService()//IdentityDbContext applicationIdentityDbContext)
        {
           // _identityDbContext = applicationIdentityDbContext;
        }
        public ApplicationUser CreateUser(string username)
        {
            var result = new ApplicationUser(username);
            return result;
        }
        public bool Login(string userName, string password)
        {
            return true;
        }
       // public IEnumerable<string> GetUsers()
       // {
          //  var result = _identityDbContext.Users.Select(x => x.UserName).AsEnumerable();
          // return result;
       // }
    }
}
