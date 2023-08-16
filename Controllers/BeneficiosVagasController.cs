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
    [Route("controller")]

    public class BeneficiosVagasController : ControllerBase
    {
        private readonly DataContext _context;

        public BeneficiosVagasController(DataContext context)
        {
            _context = context;
        }


        // Adicionar Formação Academica
        [HttpPost]
        public async Task<IActionResult> Add(BeneficioVaga CadastrarBeneficioVaga)
        {
            try
            {
                await _context.BeneficiosVagas.AddAsync(CadastrarBeneficioVaga);
                await _context.SaveChangesAsync();

                return Ok(CadastrarBeneficioVaga.idBeneficio);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut()]
        public async Task<IActionResult> Update(BeneficioVaga AlterarBeneficioVaga)
        {
            try
            {
                /*var cliente = await _context.Clientes.FirstOrDefaultAsync(p => p.Id == clienteAtualizado.Id);

                if (cliente == null)
                {
                    throw new Exception("Cliente não pode ser nulo");
                }*/
                _context.BeneficiosVagas.Update(AlterarBeneficioVaga);
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
                BeneficioVaga bvRemover = await _context.BeneficiosVagas.FirstOrDefaultAsync(bv => bv.idBeneficio == id);

                _context.BeneficiosVagas.Remove(bvRemover);
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
                List<BeneficioVaga> lista = await _context.BeneficiosVagas.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Consultar")]
        public async Task<IActionResult> Consultar(string idVaga)
        {
            try
            {
                // Consulta a carreira com base no curso
                List<BeneficioVaga> lista = await _context.BeneficiosVagas.Where(bv => bv.idVaga.Contains(idVaga)).ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


















    }
}