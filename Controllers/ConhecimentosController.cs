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
    public class ConhecimentosController : ControllerBase
    {

        private readonly DataContext _context;

        public ConhecimentosController(DataContext context)
        {
            _context = context;
        }


        // Adicionar Formação Academica
        [HttpPost]
        public async Task<IActionResult> Add(Conhecimento CadastrarConhecimento)
        {
            try
            {
                await _context.Conhecimentos.AddAsync(CadastrarConhecimento);
                await _context.SaveChangesAsync();

                return Ok(CadastrarConhecimento.ConhecimentoId);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut()]
        public async Task<IActionResult> Update(Conhecimento AlterarConhecimento)
        {
            try
            {
                /*var cliente = await _context.Clientes.FirstOrDefaultAsync(p => p.Id == clienteAtualizado.Id);

                if (cliente == null)
                {
                    throw new Exception("Cliente não pode ser nulo");
                }*/
                _context.Conhecimentos.Update(AlterarConhecimento);
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
                Conhecimento conheRemover = await _context.Conhecimentos.FirstOrDefaultAsync(conhe => conhe.ConhecimentoId == id);

                _context.Conhecimentos.Remove(conheRemover);
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
                List<Conhecimento> lista = await _context.Conhecimentos.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Consultar")]
        public async Task<IActionResult> Consultar(string nomeConhecimento)
        {
            try
            {
                // Consulta a carreira com base no curso
                List<Conhecimento> lista = await _context.Conhecimentos.Where(form => form.nomeConhecimento.Contains(nomeConhecimento)).ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }














    }
}