using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UijobsApi.Data;
using UijobsApi.Models;

namespace UijobsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormacoesAcademicasController : ControllerBase
    {
        private readonly DataContext _context;

        public FormacoesAcademicasController(DataContext context)
        {
            _context = context;
        }


        // Adicionar Formação Academica
        [HttpPost]
        public async Task<IActionResult> Add(FormacaoAcademica CadastrarFormacao)
        {
            try
            {
                await _context.FormacoesAcademicas.AddAsync(CadastrarFormacao);
                await _context.SaveChangesAsync();

                return Ok(CadastrarFormacao.idFormacaoAcademica);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut()]
        public async Task<IActionResult> Update(FormacaoAcademica AlterarFormacaoAcademica)
        {
            try
            {
                /*var cliente = await _context.Clientes.FirstOrDefaultAsync(p => p.Id == clienteAtualizado.Id);

                if (cliente == null)
                {
                    throw new Exception("Cliente não pode ser nulo");
                }*/
                    _context.FormacoesAcademicas.Update(AlterarFormacaoAcademica);
                    int linhaAfetadas = await _context.SaveChangesAsync();


                return Ok(linhaAfetadas);
            }   
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

         [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                FormacaoAcademica formRemover = await _context.FormacoesAcademicas.FirstOrDefaultAsync(form => form.idFormacaoAcademica == id);

                _context.FormacoesAcademicas.Remove(formRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Listar
         [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<FormacaoAcademica> lista = await _context.FormacoesAcademicas.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Consultar")]
    public async Task<IActionResult> Consultar(string idCurso)
    {
        try
        {
            // Consulta a carreira com base no curso
            List<FormacaoAcademica> lista = await _context.FormacoesAcademicas.Where(form => form.idCurso.Contains(idCurso)).ToListAsync();
            return Ok(lista);
        }
        catch (System.Exception ex)
        {   
            return BadRequest(ex.Message);
        }
    }






















    }
}