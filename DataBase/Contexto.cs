using Controle_Estoque_Mvc.Models;
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
        public DbSet<Entrada> Entrada { get; set; }

        

    }
}
