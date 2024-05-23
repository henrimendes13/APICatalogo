﻿using APICatalogo.DTOs;

namespace APICatalogo.Services;

public interface ICategoriaService
{
    Task<IEnumerable<CategoriaDTO>> GetCategorias();
    Task<IEnumerable<CategoriaDTO>> GetCategoriasProdutos();
    Task<CategoriaDTO> GetCategoriaById(int id);
    Task AddCategoria(CategoriaDTO categoriaDto);
    Task UpdateCategoria(CategoriaDTO categoriaDto); 
    Task RemoveCategoria(int id);    

}
