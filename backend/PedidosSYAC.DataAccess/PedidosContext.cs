using Microsoft.EntityFrameworkCore;
using PedidosSYAC.DataAccess.Entity;

namespace PedidosSYAC.DataAccess
{
    public class PedidosContext : DbContext
    {
        public PedidosContext(
            DbContextOptions<PedidosContext> options) : base(options) 
        { 
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<ProductosXPedido> ProductosXPedido { get; set; }


        //se agregan los estados :) para evitar la molestia de crearlos XD
        //pdt: se puede agregar el singleton para su llamado y evitar estar haciendo la consulta
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>().ToTable("Productos");
            modelBuilder.Entity<Estados>().HasData(
                    new() { Id = 1, Estado = "Registrado" },
                    new() { Id = 2, Estado = "Confirmar" },
                    new() { Id = 3, Estado = "Anular" }
            );
        }

    }
}