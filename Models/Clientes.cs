using System.ComponentModel.DataAnnotations;

namespace Gestao_Estoque_Mvc.Models
{
    public class Clientes
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Endereco { get; set; }
    }
}
