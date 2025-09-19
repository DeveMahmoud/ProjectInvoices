using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InvoiceDbContext :IdentityDbContext<ApplicationUser, ApplicationRole, string>

    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options)
        {
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Store>().HasData(
              new Store { Id = 1, Name = "Main Store" },
              new Store { Id = 2, Name = "Branch Store" }
          );

            modelBuilder.Entity<Unit>().HasData(
                new Unit { Id = 1, Name = "Piece" },
                new Unit { Id = 2, Name = "Box" },
                new Unit { Id = 3, Name = "Kg" }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "Laptop", UnitId = 1 },
                new Item { Id = 2, Name = "Mouse", UnitId = 1 }
            );
              



            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InvoiceDbContext).Assembly);
        }

    }
}
