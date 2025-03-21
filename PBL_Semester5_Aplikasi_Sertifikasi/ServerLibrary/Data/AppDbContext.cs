using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Assesse> assesses {  get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<ApplicationUser> applicationUsers {  get; set; }
    }
}
