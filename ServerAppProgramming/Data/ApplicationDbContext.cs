using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServerAppProgramming.Models;

namespace ServerAppProgramming.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Meals> Meals { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Restaurants> Restaurants { get; set; }
    }
}
