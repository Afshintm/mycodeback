using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Essence.Communication.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        private UserReference _userRef;
        public ApplicationUser() {
            Id = Guid.NewGuid().ToString();
            _userRef = new UserReference() { Id = Id } ;
        }

        public ApplicationUser(string userName) : base(userName) { }

        public UserReference UserRef
        {
            get
            {
                return _userRef;
            }
            set
            {
                _userRef = value;
                _userRef.Id = Id;
                Email = value.Email;
                UserType = value.UserType;
                CellPhoneNumber = value.CellPhoneNumber;
                Gender = value.Gender;
                Address = value.Address;
                FirstName = value.FirstName;
                LastName = value.LastName;
                UserName = value.UserName;
            }
        }

        public override string Email { get; set; }
        public string UserType { get; set; }
        public string CellPhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }
}
