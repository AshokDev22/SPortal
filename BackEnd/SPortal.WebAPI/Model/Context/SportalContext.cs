
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SPortal.WebAPI.Model.Entities;

namespace SPortal.WebAPI.Model.Context
{
    public class SPortalContext:DbContext
    {
        public SPortalContext(DbContextOptions<SPortalContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(e=>{
                e.HasKey(c=>c.CID);
                e.Property(p=>p.CID).ValueGeneratedNever();
                e.Property(p=>p.CName).HasColumnName("catName");
                e.HasMany<Product>(p=>p.Products).WithOne(pr=>pr.PCategory).HasForeignKey(pr=>pr.CatID);
            });
            modelBuilder.Entity<Product>(e=>{
                e.HasKey(p=>p.PID);
                e.Property(p=>p.PName).HasColumnName("PName");
                e.Property(p=>p.CatID).HasColumnName("CatID");
                e.Property(p=>p.PID).HasColumnName("PID");
                e.Property(p=>p.Price).HasColumnName("Rate");
                e.Property(p=>p.AvailableQuantity).HasColumnName("AQty");
            });            
        }

        public virtual DbSet<Category> Categories{get;set;}
        public virtual DbSet<Product> Products{get;set;}
    }
}




