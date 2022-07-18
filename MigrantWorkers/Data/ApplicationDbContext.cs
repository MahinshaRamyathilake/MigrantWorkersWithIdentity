using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MigrantWorkers.Models;

namespace MigrantWorkers.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SLFB_User> SLFBUsers { get; set; }
        //public DbSet<MigrantWorkers.Models.SLFB_User_Input>? SLFB_User_Input { get; set; }
        public DbSet<Embassy> Embassies { get; set; }

        public DbSet<Agency> Agencies { get; set; }
    }
}