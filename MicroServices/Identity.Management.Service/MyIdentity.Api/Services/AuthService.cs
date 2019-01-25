using MyIdentity.DataAccess;
using MyIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyIdentity.Api.Services
{
    public interface IAuthService
    {
        ApplicationUser CreateUser(string username);
        bool Login(string userName, string password);
        IEnumerable<string> GetUsers();
    }
    public class AuthService : IAuthService
    {
        ApplicationIdentityDbContext _applicationIdentityDbContext;
        public AuthService(ApplicationIdentityDbContext applicationIdentityDbContext) {
            _applicationIdentityDbContext = applicationIdentityDbContext;
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
        public IEnumerable<string> GetUsers() {
            var result = _applicationIdentityDbContext.Users.Select(x => x.UserName).AsEnumerable();
            return result;
        }
    }
}
