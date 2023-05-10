using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


namespace TheWorkFlow.Models
{
    public class WorkflowDbContext:IdentityDbContext
    {
        public WorkflowDbContext(DbContextOptions<WorkflowDbContext> options) : base(options)
        {

        }       
        public virtual DbSet<IdentityUser> ApplicationUser { get; set; }
        public virtual DbSet<FileMaster> FileMaster { get; set; }
        public virtual DbSet<HBLMaster> HBLMasters { get; set; }
        public virtual DbSet<FileActivityLog> FileActivityLog { get; set; }
        public virtual DbSet<HBLActivityLog> HBLActivityLog { get; set; }
        public virtual DbSet<FileActivityLogHistory> FileActivityLogHistory { get; set; }
        public virtual DbSet<HBLActivityLogHistory> HBLActivityLogHistory { get; set; }
        public virtual DbSet<ActivityMaster> ActivityMaster { get; set; }
        public virtual DbSet<StatusMaster> StatusMaster { get; set; }
        public virtual DbSet<CountryMaster> CountryMaster { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>(entity => {
                entity.ToTable("Users");
            });

            builder.Entity<IdentityRole>(entity => {
                entity.ToTable("Roles");
            });

            builder.Entity<IdentityUserRole<string>>(entity => {
                entity.ToTable("UserRoles");
            });

            builder.Entity<FileActivityLog>()
                .HasOne(f => f.ActivityMaster)
                .WithMany()
                .HasForeignKey(f => f.ActivityId)
                .HasPrincipalKey(a => a.Id);

            builder.Entity<HBLActivityLog>()
                .HasOne(f => f.HBLMaster)
                .WithMany()
                .HasForeignKey(f => f.ActivityId)
                .HasPrincipalKey(a => a.Id);

            builder.Entity<HBLActivityLog>()
               .HasOne(f => f.StatusMaster)
               .WithMany()
               .HasForeignKey(f => f.StatusId)
               .HasPrincipalKey(a => a.Id);

            builder.Entity<HBLActivityLog>()
               .HasOne(f => f.ActivityMaster)
               .WithMany()
               .HasForeignKey(f => f.ActivityId)
               .HasPrincipalKey(a => a.Id);

        }

    }
}
