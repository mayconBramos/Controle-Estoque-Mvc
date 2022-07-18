using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_Estoque_Mvc.Models
{
        [Table("Entrada-Estoque")]
        public class Entrada
        {
            [Column("Id")]
            [Display(Name = "Id")]
        
            public int Id { get; set; }

            [Column("Lote")]
            [Display(Name = "Lote")]
        [Required(ErrorMessage = "Campo Obrigatório")]
            public string Lote { get; set; }

            [Column("Nome/Marca")]
            [Display(Name = "Nome/Marca")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string NomeProduto { get; set; }

            [Column("Quantidade")]
            [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Quantidade { get; set; }

            [Column("Recebimento")]
            [Display(Name = "Recebimento")]
            [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Recebimento { get; set; }

            [Column("Validade")]
            [Display(Name = "Validade")]
            [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Validade { get; set; }
        }

}