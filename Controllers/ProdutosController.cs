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
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutosController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetProdutos()
    {
        var produtosDto = await _produtoService.GetProdutos();
        if (produtosDto == null)
        {
            return NotFound("Categorias Not Found");
        }

        return Ok(produtosDto);
    }


    [HttpGet("{id:int}", Name = "GetProduto")]
    public async Task<ActionResult<ProdutoDTO>> GetProduto(int id)
    {
        var produtoDto = await _produtoService.GetProdutoById(id);

        if (produtoDto == null)
        {
            return NotFound("Produto Not Found");
        }

        return produtoDto;
    }


    [HttpPost]
    public async Task<ActionResult> PostProduto([FromBody] ProdutoDTO produtoDTO)
    {
        if (produtoDTO == null)
        {
            return BadRequest("Dados Invalidos");
        }

        await _produtoService.AddProduto(produtoDTO);

        return new CreatedAtRouteResult("GetCategoria", new { id = produtoDTO.CategoriaId }, produtoDTO);
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutProduto(int id, [FromBody] ProdutoDTO produtoDto)
    {
        if (id != produtoDto.CategoriaId)
        {
            return BadRequest();
        }

        if (produtoDto == null)
        {
            return BadRequest();
        }

        await _produtoService.UpdateProduto(produtoDto);

        return Ok(produtoDto);
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ProdutoDTO>> DeleteProduto(int id)
    {
        var produtoDto = await _produtoService.GetProdutoById(id);
        if (produtoDto == null)
        {
            return NotFound("Categoria Not Found");
        }

        await _produtoService.RemoveProduto(id);

        return Ok(produtoDto);
    }


}
