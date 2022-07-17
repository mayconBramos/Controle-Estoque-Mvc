using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoque.Models
{
    [Table("Entrada-Estoque")]
    public class Entrada
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Lote")]
        [Display(Name = "Lote")]
        public string Lote { get; set; }

        [Column("Nome/Marca")]
        [Display(Name = "Nome/Marca")]
        public string NomeProduto { get; set; }

        [Column("Quantidade")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Column("Recebimento")]
        [Display(Name = "Recebimento")]
        [DataType(DataType.Date)]
        public DateTime Recebimento { get; set; }

        [Column("Retirada")]
        [Display(Name = "Retirada")]
        [DataType(DataType.Date)]
        public DateTime Retirada { get; set; }

        [Column("Validade")]
        [Display(Name = "Validade")]
        [DataType(DataType.Date)]
        public DateTime Validade { get; set; }
    }
}
