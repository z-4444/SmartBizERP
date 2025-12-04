using Microsoft.EntityFrameworkCore;
using SmartBiz.Core.Entities;
using SmartBiz.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartBiz.Infrastructure.Data
{
    public class SmartBizDbContext : DbContext
    {
        public SmartBizDbContext(DbContextOptions<SmartBizDbContext> options) : base(options)
        {
        }

        // DbSets for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<Inventory> Inventory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure enums to store as strings for readability
            modelBuilder.Entity<Role>()
                .Property(u => u.RoleName)
                .HasConversion<string>();

            modelBuilder.Entity<Order>()
                .Property(o => o.Status)
                .HasConversion<string>();

            modelBuilder.Entity<InventoryTransaction>().Property(it => it.Type).HasConversion<string>();

            // Configure User relationships
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.InventoryTransactions)
                .WithOne(it => it.User)
                .HasForeignKey(it => it.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.InventoryTransactions)
                .WithOne(it => it.Product)
                .HasForeignKey(it => it.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InventoryTransaction>()
                .HasOne(it => it.Product)
                .WithMany(p => p.InventoryTransactions)
                .HasForeignKey(it => it.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Inventory)      // Product has one Inventory
                .WithOne(i => i.Product)       // Inventory has one Product
                .HasForeignKey<Inventory>(i => i.ProductId)  // FK is in Inventory table
                .OnDelete(DeleteBehavior.Cascade);  // optional, set your preferred delete behavior

        }


    }
}
        