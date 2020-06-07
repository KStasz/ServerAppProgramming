using System;
using System.ComponentModel.DataAnnotations;

namespace ServerAppProgramming.Models
{
    public class Permissions
    {
        [Key]
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
