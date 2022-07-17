using ControleEstoque.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoque.DataBase
{

    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        //Criando tabela
        public DbSet<Estoque> Estoque { get; set; }

        //Criando tabela
        public DbSet<ControleEstoque.Models.Entrada>? Entrada { get; set; }

        //Criando tabela
        public DbSet<ControleEstoque.Models.Saida>? Saida { get; set; }
    }
}
