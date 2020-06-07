using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ServerAppProgramming.Models
{
    public class UserModel : IdentityUser
    {
        public int PermissionId { get; set; }
    }
}
