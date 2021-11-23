using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models.ViewModels
{
    public class RegistrarNovoUsuarioViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "A {0} precisa ter ao  menos {2} e no máximo {1} caracteres de comprimento."
            , MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar  senha")]
        [Compare("Password", ErrorMessage = "Os valores informados para SENHA e CONFIRMAÇÃO não são iguais.")]
        public string ConfirmPassword { get; set; }
    }

}

