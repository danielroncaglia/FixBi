using System.ComponentModel.DataAnnotations;

namespace Fixbi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Infome seu e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Infome seu senha")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Até 10 caracteres")]
        public string Senha { get; set; }
    }
}