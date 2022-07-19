using Controle_Estoque_Mvc.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_Estoque_Mvc.Models
{
    [Table("Cadastro-Usuarios")]
    public class Usuario
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Column("Login")]
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Login { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido")]
        public string Email { get; set; }

        [Column("Perfil")]
        [Display(Name = "Perfil")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public PerfilEnum? Perfil { get; set; }

        [Column("Senha")]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo Obrigatório")]

        public string Senha { get; set; }

        [Column("Cadastro")]
        [Display(Name = "Cadastro")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        [Column("Atualização")]
        [Display(Name = "Atualização")]
        [DataType(DataType.Date)]
        public DateTime? DataAtualizacao { get; set; }
    }
}
