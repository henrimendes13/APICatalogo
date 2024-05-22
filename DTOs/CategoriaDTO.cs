using APICatalogo.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APICatalogo.DTOs
{
    public class CategoriaDTO
    {
        public CategoriaDTO()
        {
            Produtos = new Collection<Produto>();
        }
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "O Nome é Obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A Imagem é Obrigatória")]
        [MinLength(5)]
        [MaxLength(255)]
        public string? ImagemUrl { get; set; }
        public ICollection<Produto>? Produtos { get; set; }
    }
}
