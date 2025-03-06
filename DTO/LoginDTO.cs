using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api_filmes_senai.DTO
{
    public class LoginDTO
    {
       
        [Required(ErrorMessage = "O Email e obrigatorio")]

        public string? Email { get; set; }

      
        [Required(ErrorMessage = "A Senha e obrigatoria")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter no minimo 6 caracteres e no maximo 60")]

        public string? Senha { get; set; }

    }
}
