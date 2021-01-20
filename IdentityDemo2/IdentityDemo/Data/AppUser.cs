using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityDemo.Data
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
        }

        public AppUser(string userName) : base(userName)
        {
        }

        public string ManagerId { get; set; }
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("ManagerId")]
        public AppUser Manager { get; set; }
    }
}
