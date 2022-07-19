using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestao_Estoque_Mvc.Models
{
    [Table("Produtos")]
    public class Produto
    {

        [Column("Id")]

        public int Id { get; set; }

        [Column("Lote")]
        [Required(ErrorMessage = "Campo Obrigatório")]

        public string Lote { get; set; }

        [Column("Nome/Marca")]
        [Required(ErrorMessage = "Campo Obrigatório")]

        public string NomeProduto { get; set; }

        [Column("Quantidade")]
        [Required(ErrorMessage = "Campo Obrigatório")]

        public int Quantidade { get; set; }

        [Column("Recebimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Recebimento { get; set; }

        [Column("Validade")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Validade { get; set; }

    }
}
