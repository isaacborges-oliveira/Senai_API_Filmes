using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api_filmes_senai.Domains
{
    public class Filme
    {
        [Key]
        public Guid IdFilmes { get; set; }

        [Column(TypeName = "VARCHAR (50)")]
        [Required(ErrorMessage = "O titulo do filme é obrigatorio!")]
        public string? Titulo { get; set; }
        /// <summary>
        /// Referencia da tabela de Genero
        /// </summary>
        public Guid IdGenero { get; set; }

        [ForeignKey("IdGenero")]
        public Genero? Genero { get; set; }
    }
}
