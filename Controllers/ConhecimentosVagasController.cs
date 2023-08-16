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

    public class ConhecimentosVagasController : ControllerBase
    {


        private readonly DataContext _context;

        public ConhecimentosVagasController (DataContext context)
        {
            _context = context;
        }


        // Adicionar Formação Academica
        [HttpPost]
        public async Task<IActionResult> Add(ConhecimentoVaga CadastrarConhecimentoVaga)
        {
            try
            {
                await _context.ConhecimentosVagas.AddAsync(CadastrarConhecimentoVaga);
                await _context.SaveChangesAsync();

                return Ok(CadastrarConhecimentoVaga.idConhecimento);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Conhecimento convRemover = await _context.Conhecimentos.FirstOrDefaultAsync(conv => conv.ConhecimentoId == id);

                _context.Conhecimentos.Remove(convRemover);
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
                List<ConhecimentoVaga> lista = await _context.ConhecimentosVagas.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Consultar")]
        public async Task<IActionResult> Consultar(string idNivel)
        {
            try
            {
                // Consulta a carreira com base no curso
                List<ConhecimentoVaga> lista = await _context.ConhecimentosVagas.Where(form => form.idNivel.Contains(idNivel)).ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}