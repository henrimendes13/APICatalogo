using APICatalogo.DTOs;
using APICatalogo.Models;
using APICatalogo.Repositories;
using AutoMapper;

namespace APICatalogo.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;

    public ProdutoService(IProdutoRepository produtoReposiory, IMapper mapper)
    {
        _produtoRepository = produtoReposiory;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
    {
        var produtosEntity = await _produtoRepository.GetAll();
        return _mapper.Map<IEnumerable<ProdutoDTO>>(produtosEntity);
    }

    public async Task<ProdutoDTO> GetProdutoById(int id)
    {
        var produtoEntity = await _produtoRepository.GetbyId(id);
        return _mapper.Map<ProdutoDTO>(produtoEntity);
    }

    public async Task AddProduto(ProdutoDTO produtoDto)
    {
        var produtoEntity = _mapper.Map<Produto>(produtoDto);
        await _produtoRepository.Create(produtoEntity);
        produtoDto.ProdutoId = produtoEntity.ProdutoId;
    }

    public async Task UpdateProduto(ProdutoDTO produtoDto)
    {
        var produtoEntity = _mapper.Map<Produto>(produtoDto);
        await _produtoRepository.Update(produtoEntity);
    }

    public async Task RemoveProduto(int id)
    {
        var produtoEntity = _produtoRepository.GetbyId(id).Result;
        await _produtoRepository.Delete(produtoEntity.ProdutoId);
    }


}
