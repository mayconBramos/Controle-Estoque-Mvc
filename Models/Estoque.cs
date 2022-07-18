using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_Estoque_Mvc.Models
{
    [Table("Estoque")]
    public class Estoque
    {

        [Column("Id")]

        public int Id { get; set; }

        [Column("Lote")]

        public string Lote { get; set; }

        [Column("Nome/Marca")]

        public string NomeProduto { get; set; }

        [Column("Quantidade")]

        public int Quantidade { get; set; }

        [Column("Recebimento")]

        [DataType(DataType.Date)]
        public DateTime Recebimento { get; set; }

        [Column("Validade")]

        [DataType(DataType.Date)]
        public DateTime Validade { get; set; }

    }
}
