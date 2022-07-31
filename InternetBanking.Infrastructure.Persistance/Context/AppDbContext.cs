using InternetBanking.Core.Application.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Core.Application.Helpers;
using RestaurantAPI.Core.Domain.Common;
using RestaurantAPI.Core.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantAPI.Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private UserViewModel user = new();

        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor http) : base(options)
        {
            _httpContextAccessor = http;
        }

        #region dbSets -->
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Plate> Plate { get; set; }
        public DbSet<PlateCategory> CategoryPlate { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<TableStatus> TableStatus { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<PlateIngredient> PlateIngredient { get; set; }




        #endregion

        public override Task<int> SaveChangesAsync(CancellationToken ct = new())
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                user = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
            }

            //foreach (var entry in ChangeTracker.Entries<AuditableBE>())
            //{
            //    switch (entry.State)
            //    {
            //        //case EntityState.Added:
            //        //    entry.Entity.Created = DateTime.Now;
            //        //    entry.Entity.CreatedBy = user.UserName;

            //        //    break;
            //        //case EntityState.Modified:
            //        //    entry.Entity.LastModified = DateTime.Now;
            //        //    entry.Entity.ModifiedBy = user.UserName;
            //        //    break;
            //    }
            //}

            return base.SaveChangesAsync(ct);
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            #region tables

            mb.Entity<Ingredient>()
                .ToTable("Ingredient");

            mb.Entity<Plate>()
                .ToTable("Plate");

            mb.Entity<PlateCategory>()
                .ToTable("CategoryPlate");

            mb.Entity<Table>()
                .ToTable("Table");

            mb.Entity<TableStatus>()
                .ToTable("TableStatus");

            #endregion

            #region primary keys

            mb.Entity<Ingredient>()
                .HasKey(e => e.Id);

            mb.Entity<Plate>()
                .HasKey(e => e.Id);

            mb.Entity<PlateCategory>()
                .HasKey(e => e.Id);

            mb.Entity<Table>()
                .HasKey(e => e.Id);

            mb.Entity<TableStatus>()
                .HasKey(e => e.Id);

            #endregion

            #region relations
            mb.Entity<Plate>()
               .HasMany<Ingredient>(e => e.Ingredinets)
               .WithMany(e => e.Plates);

            mb.Entity<PlateCategory>()
                .HasMany<Plate>(e => e.Plates)
                .WithOne(e => e.PlateCategory)
                .HasForeignKey(e => e.PlateCategoryId);


            #endregion

            #region property configurations

            #region Ingredient

            #endregion


            #endregion
        }
    }
}
