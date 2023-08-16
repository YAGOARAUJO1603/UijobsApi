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

    public class CandidatosController : ControllerBase
    {
        
      private readonly DataContext _context; // Declaração de

        public CandidatosController(DataContext context)
        {
            //Inicialização do atributo a partir de um parâmetro          
            _context = context;
        }

        [HttpGet("{id}")] //Buscar pelo id
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Candidato c = await _context.Candidatos
                    .FirstOrDefaultAsync(cBusca => cBusca.Id == id);

                return Ok(c);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Listar todos os Candidatos
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Candidato> lista = await _context.Candidatos.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Candidato novoCandidato)
        {
            try
            {
                await _context.Candidatos.AddAsync(novoCandidato);
                await _context.SaveChangesAsync();

                return Ok(novoCandidato.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Update(Candidato candidatoAtualizado)
        {
            try
            {
                /*var cliente = await _context.Clientes.FirstOrDefaultAsync(p => p.Id == clienteAtualizado.Id);

                if (cliente == null)
                {
                    throw new Exception("Cliente não pode ser nulo");
                }*/
                    _context.Candidatos.Update(candidatoAtualizado);
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
                Candidato cRemover = await _context.Candidatos.FirstOrDefaultAsync(c => c.Id == id);

                _context.Candidatos.Remove(cRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }   
























    }
}