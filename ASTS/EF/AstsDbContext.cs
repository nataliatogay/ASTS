using ASTS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.EF
{
    public class AstsDbContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<MaterialGroup> MaterialGroups { get; set; }
        public DbSet<MaterialUnit> MaterialUnits { get; set; }
        public DbSet<AccountCode> AccountCodes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialRequest> MaterialRequests { get; set; }
        public DbSet<RequestedMaterial> RequestedMaterials { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<User> ApplicationUsers { get; set; }

        public AstsDbContext(DbContextOptions options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.MaterialRequestsIssued).WithOne(r => r.IssuedByUser).HasForeignKey(r => r.IssuedByUserId);

            modelBuilder.Entity<User>().HasMany(u => u.MaterialRequestsDiscManager).WithOne(r => r.DisciplineManagerUser).HasForeignKey(r => r.DisciplineManagerUserId);

            modelBuilder.Entity<User>().HasMany(u => u.MaterialRequestsCostControl).WithOne(r => r.CostControlUser).HasForeignKey(r => r.CostControlUserId);

            modelBuilder.Entity<User>().HasMany(u => u.MaterialRequestsProjectManager).WithOne(r => r.ProjectManagerUser).HasForeignKey(r => r.ProjectManagerUserId);

            modelBuilder.Entity<User>().HasMany(u => u.MaterialRequestsDirector).WithOne(r => r.DirectorUser).HasForeignKey(r => r.DirectorUserId);

            modelBuilder.Entity<RequestedMaterial>().HasOne(r => r.MaterialRequest).WithMany(m => m.RequestedMaterials).OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
