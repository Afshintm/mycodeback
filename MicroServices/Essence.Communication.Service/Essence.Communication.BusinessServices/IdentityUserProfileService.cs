using Essence.Communication.DbContexts;
using Essence.Communication.Models.IdentityModels;
using Services.Utilities.DataAccess;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Essence.Communication.BusinessServices
{
    public interface IIdentityUserProfileService
    {
        Task<bool> UpdateUserProfiles(IEnumerable<ApplicationUser> users);
    }

    public class IdentityUserProfileService : IIdentityUserProfileService
    {
        private readonly IUnitOfWork<IdentityDbContext> _unitOfWork;

        private List<IdentityRole> _roles;
        private IRepository<ApplicationUser> _userRepo;
        private IRepository<IdentityUserRole<string>> _userRolesRepo;
        private IRepository<IdentityRole> _rolesRepo;

        public IdentityUserProfileService (IUnitOfWork<IdentityDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepo = _unitOfWork.Repository<ApplicationUser>();
            _userRolesRepo = _unitOfWork.Repository<IdentityUserRole<string>>();
            _rolesRepo = _unitOfWork.Repository<IdentityRole>();
            _roles = _rolesRepo.GetAll().ToList();
        }

        public async Task<bool> UpdateUserProfiles(IEnumerable<ApplicationUser> users)
        {
            //add /update users
            _userRepo.InsertRange(users);

            //get user role mapping
            var userRoles = users.Select(x => new IdentityUserRole<string> { RoleId = GetRoleId(x.UserType), UserId = x.Id })
                .Where( r => !string.IsNullOrEmpty(r.RoleId));
            _userRolesRepo.InsertRange(userRoles);

            _unitOfWork.Save();

            return true;
        }

        private string GetRoleId(string roleName)
        {
            var result = _roles.Where(x => string.Compare(roleName, x.Name, true) == 0).FirstOrDefault();
            return result?.Id;
        }
    }
}
