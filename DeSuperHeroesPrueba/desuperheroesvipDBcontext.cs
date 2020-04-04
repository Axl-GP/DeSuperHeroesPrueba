using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeSuperHeroesPrueba.Models
{
    public class desuperheroesvipDBcontext : DbContext
    {
        public desuperheroesvipDBcontext(DbContextOptions opciones) : base(opciones)
        { }
            public DbSet<Cliente> Cliente { get; set; }
            public DbSet<proveedor> proveedor { get; set; }
            public DbSet<stock> stock { get; set; }
            public DbSet<producto> producto { get; set; }
            public DbSet<Factura> factura { get; set; }
            public DbSet<producto_cliente> producto_cliente { get; set; }
            public DbSet<producto_proveedor> producto_proveedor { get; set; }
        
        protected override void OnModelCreating(ModelBuilder crear)
        {
            new Cliente.mapear(crear.Entity<Cliente>());
            
            new stock.mapear(crear.Entity<stock>());
            new proveedor.mapear(crear.Entity<proveedor>());
            new producto.mapear(crear.Entity<producto>());
            new Factura.mapear(crear.Entity<Factura>());
            new producto_cliente.mapear(crear.Entity<producto_cliente>());
            new producto_proveedor.mapear(crear.Entity<producto_proveedor>());
        }
    }
    }

