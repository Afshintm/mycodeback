using Essence.Communication.DbContexts;
using Essence.Communication.Models.IdentityModels;
using System.Collections.Generic;
using System.Linq;

namespace Essence.Communication.BusinessServices
{
    public interface IAuthService
    {
        ApplicationUser CreateUser(string username);
        bool Login(string userName, string password);
        IEnumerable<string> GetUsers();
        void Test();
    }
    public class AuthService : IAuthService
    {
        IIdentityUserContext _applicationIdentityDbContext;
        public AuthService(IIdentityUserContext applicationIdentityDbContext)
        {
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
        public IEnumerable<string> GetUsers()
        {
            var result = _applicationIdentityDbContext.Users.Select(x => x.UserName).AsEnumerable();
            return result;
        }
        public void Test()
        {

        }
    }
}
