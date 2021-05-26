using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class ApplicationDbContext: DbContext 
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Factura");
                entity.Property(x => x.BillId).HasColumnName("Facturaid").UseIdentityColumn();
                entity.Property(x => x.Quantity).HasColumnName("Cantidad");
                entity.Property(x => x.Date).HasColumnName("Fecha");
                entity.Property(x => x.Total).HasColumnName("Total");
                entity.Property(x => x.ClientId).HasColumnName("Clienteid");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Cliente");
                entity.Property(x => x.Id).HasColumnName("Id").UseIdentityColumn();
                entity.Property(x => x.Name).HasColumnName("Nombre");
                entity.Property(x => x.RNC).HasColumnName("RNC");
                entity.Property(x => x.Email).HasColumnName("Email");
                entity.Property(x => x.Category).HasColumnName("Categoria");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Producto");
                entity.Property(x => x.Id).HasColumnName("Id").UseIdentityColumn();
                entity.Property(x => x.Name).HasColumnName("Nombre");
                entity.Property(x => x.Price).HasColumnName("Precio");
                entity.Property(x => x.StockId).HasColumnName("StockId");
            });

            modelBuilder.Entity<ProductClient>(entity =>
            {
                entity.ToTable("Producto_Cliente");
                entity.Property(x => x.ProductClientId).HasColumnName("Producto_ClienteId").UseIdentityColumn();
                entity.Property(x => x.ProductId).HasColumnName("ProductoId");
                entity.Property(x => x.ClientId).HasColumnName("ClienteId");
                entity.Property(x => x.Quantity).HasColumnName("Cantidad");
                entity.Property(x => x.BillDate).HasColumnName("FechaFactura");
            });

            modelBuilder.Entity<ProductProvider>(entity =>
            {
                entity.ToTable("Producto_Proveedor");
                entity.Property(x => x.ProductProviderId).HasColumnName("Producto_ProveedorId").UseIdentityColumn();
                entity.Property(x => x.ProductId).HasColumnName("ProductoId");
                entity.Property(x => x.ProviderId).HasColumnName("ProveedorId");
                entity.Property(x => x.Quantity).HasColumnName("Cantidad");
                entity.Property(x => x.ImportDate).HasColumnName("FechaImporte");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("Proveedor");
                entity.Property(x => x.Id).HasColumnName("Id").UseIdentityColumn();
                entity.Property(x => x.Name).HasColumnName("Nombre");
                entity.Property(x => x.RNC).HasColumnName("RNC");
                entity.Property(x => x.Email).HasColumnName("Email");
                entity.Property(x => x.PhoneNumber).HasColumnName("Telefono");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("Stock");
                entity.Property(x => x.Id).HasColumnName("Id").UseIdentityColumn();
                entity.Property(x => x.ProductType).HasColumnName("TipoProducto");
                entity.Property(x => x.Quantity).HasColumnName("Existencia");
                entity.Property(x => x.LastDate).HasColumnName("UltimaFecha");
                entity.Property(x => x.Image).HasColumnName("Img");
            });
        }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductClient> Sells { get; set; }
        public DbSet<ProductProvider> Entries { get; set; }
        public DbSet<Stock> Stocks { get; set; }


    }
}
