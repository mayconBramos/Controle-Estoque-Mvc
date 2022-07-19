using Gestao_Estoque_Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestao_Estoque_Mvc.Data
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Entrada> Entrada { get; set; }
        public DbSet<Clientes> Clientes { get; set; }

    }
}
