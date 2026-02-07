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
        public DbSet<Productos> Produtos { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }

    }
}