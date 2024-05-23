using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICatalogo.Data;
using APICatalogo.Models;
using APICatalogo.Services;
using APICatalogo.DTOs;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriasController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategorias()
    {
        var categoriasDto = await _categoriaService.GetCategorias();
        if (categoriasDto == null)
        {
            return NotFound("Categorias Not Found");
        }

        return Ok(categoriasDto);
    }


    [HttpGet("produtos")]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriasProdutos()
    {
        var categoriasDto = await _categoriaService.GetCategoriasProdutos();
        if (categoriasDto == null)
        {
            return NotFound("Categorias Not Found");
        }

        return Ok(categoriasDto);
    }



    [HttpGet("{id:int}", Name = "GetCategoria")]
    public async Task<ActionResult<CategoriaDTO>> GetCategoria(int id)
    {
        var categoriaDto = await _categoriaService.GetCategoriaById(id);

        if (categoriaDto == null)
        {
            return NotFound("Categoria Not Found");
        }

        return categoriaDto;
    }


    [HttpPost]
    public async Task<ActionResult> PostCategoria([FromBody] CategoriaDTO categoriaDto)
    {
        if (categoriaDto == null)
        {
            return BadRequest("Dados Invalidos");
        }

        await _categoriaService.AddCategoria(categoriaDto);

        return new CreatedAtRouteResult("GetCategoria", new { id = categoriaDto.CategoriaId }, categoriaDto);
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutCategoria(int id, [FromBody] CategoriaDTO categoriaDto)
    {
        if (id != categoriaDto.CategoriaId)
        {
            return BadRequest();
        }

        if (categoriaDto == null)
        {
            return BadRequest();
        }

        await _categoriaService.UpdateCategoria(categoriaDto);

        return Ok(categoriaDto);
    }



    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CategoriaDTO>> DeleteCategoria(int id)
    {
        var categoriaDto = await _categoriaService.GetCategoriaById(id);
        if (categoriaDto == null)
        {
            return NotFound("Categoria Not Found");
        }

        await _categoriaService.RemoveCategoria(id);

        return Ok(categoriaDto);
    }

}
