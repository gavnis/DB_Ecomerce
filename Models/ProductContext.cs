using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DiaD.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        /**
        Example for add table in db:
        public DbSet<> { get; set; }
        */
    }





}