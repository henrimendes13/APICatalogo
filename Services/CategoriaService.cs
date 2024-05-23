using APICatalogo.DTOs;
using APICatalogo.Models;
using APICatalogo.Repositories;
using AutoMapper;

namespace APICatalogo.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IMapper _mapper;

    public CategoriaService(ICategoriaRepository categoriaReposiory, IMapper mapper)
    {
        _categoriaRepository = categoriaReposiory;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
    {
        var categoriasEntity = await _categoriaRepository.GetAll();
        return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
    }

    public async Task<IEnumerable<CategoriaDTO>> GetCategoriasProdutos()
    {
        var categoriasEntity = await _categoriaRepository.GetCategoriasProdutos();
        return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
    }

    public async Task<CategoriaDTO> GetCategoriaById(int id)
    {
        var categoriaEntity = await _categoriaRepository.GetbyId(id);
        return _mapper.Map<CategoriaDTO>(categoriaEntity);
    }

    public async Task AddCategoria(CategoriaDTO categoriaDto)
    {
        var categoriaEntity = _mapper.Map<Categoria>(categoriaDto);
        await _categoriaRepository.Create(categoriaEntity);
        categoriaDto.CategoriaId = categoriaEntity.CategoriaId;
    }

    public async Task UpdateCategoria(CategoriaDTO categoriaDto)
    {
        var categoriaEntity = _mapper.Map<Categoria>(categoriaDto);
        await _categoriaRepository.Update(categoriaEntity);
    }

    public async Task RemoveCategoria(int id)
    {
        var categoriaEntity = _categoriaRepository.GetbyId(id).Result;
        await _categoriaRepository.Delete(categoriaEntity.CategoriaId);
    }


}
