using System.ComponentModel.DataAnnotations;

namespace SustentavelStartUp.Models
{
    public class UsuarioModel
    {
        public UsuarioModel()
        {

        }

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        [StringLength(80,
            MinimumLength = 2,
            ErrorMessage = "O nome deve ter, no mínimo, 2 e, no máximo, 80 caracteres")]
        [Display(Name = "Nome usuario")]
        public string? NomeUsuario { get; set; }

        [Required(ErrorMessage = "Email é obrigatório!")]
        public string? Email { get; set; }

        public string? Telefone { get; set; }

        public UsuarioModel(int idUsuario, string? nomeUsuario, string email, string telefone)
        {
            IdUsuario = idUsuario;
            NomeUsuario = nomeUsuario;
            Email = email;
            Telefone = telefone;
        }
    }
}
