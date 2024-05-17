using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICatalogo.Data;
using APICatalogo.Models;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly APIDbContext _context;

        public CategoriasController(APIDbContext context)
        {
            _context = context;
        }


        [HttpGet("produtos")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoriasProdutos()
        {
            return await _context.Categorias.Include(p=> p.Produtos).ToListAsync();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }

        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

       
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
           if (categoria == null)
            {
                return BadRequest();
            }
            
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.CategoriaId }, categoria);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(categoria);
        }

        
              
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.CategoriaId == id);
        }
    }
}
