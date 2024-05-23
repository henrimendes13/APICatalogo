using APICatalogo.Models;
using System.ComponentModel.DataAnnotations;

namespace APICatalogo.DTOs
{
    public class ProdutoDTO
    {
        public int ProdutoId { get; set; }
        
        [Required(ErrorMessage = "O Nome é Obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A Descrição é Obrigatória")]
        [MinLength(5)]
        [MaxLength(200)]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O Preço é Obrigatório")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A Imagem é Obrigatória")]
        [MinLength(5)]
        [MaxLength(255)]
        public string? ImagemUrl { get; set; }

        [Required(ErrorMessage = "O Estoque é Obrigatório")]
        [Range(1,9999)]
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CategoriaId { get; set; }
              
        public Models.Categoria? Categoria { get; set; }
    }
}
