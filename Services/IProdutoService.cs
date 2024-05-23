using APICatalogo.DTOs;

namespace APICatalogo.Services;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoDTO>> GetProdutos();
    Task<ProdutoDTO> GetProdutoById(int id);
    Task AddProduto(ProdutoDTO produtoDto);
    Task UpdateProduto(ProdutoDTO produtoDto);
    Task RemoveProduto(int id);
}
