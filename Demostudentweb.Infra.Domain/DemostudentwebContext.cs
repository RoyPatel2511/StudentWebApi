using Demostudentweb.Infra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demostudentweb.Infra.Domain
{
    public class DemostudentwebContext : DbContext
    {
        public DemostudentwebContext(DbContextOptions<DemostudentwebContext> options) : base(options)
        {

        }
        public DbSet<Student> students { get; set; }

        public DbSet<Course> courses { get; set; }  

        public DbSet<User> users { get; set; }  

        public DbSet<Role> roles { get; set; }  

        public DbSet<UserRoleMapping> roleMappings { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(new List<Course>
            {
                new Course( 1, "MCA"),
                new Course( 2, "BCA")

            }) ;
               
        }

    }
}
