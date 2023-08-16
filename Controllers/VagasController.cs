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

    public class VagasController : ControllerBase
    {
        private readonly DataContext _context;

        public VagasController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Add(Vaga CadastrarVaga)
        {
            try
            {
                await _context.Vagas.AddAsync(CadastrarVaga);
                await _context.SaveChangesAsync();

                return Ok(CadastrarVaga.idVaga);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Encerrar(int id)
        {
            try
            {
                Vaga vRemover = await _context.Vagas.FirstOrDefaultAsync(v => v.idVaga == id);

                _context.Vagas.Remove(vRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Consultar")]
        public async Task<IActionResult> Consultar(string cargo)
        {
            try
            {
                // Consulta a carreira com base no curso
                List<Vaga> lista = await _context.Vagas.Where(v => v.cargo.Contains(cargo)).ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/Suspender")]
        public async Task<IActionResult> Suspender(int id)
        {
            try
            {
                // Find the job vacancy with the given id
                Vaga vaga = await _context.Vagas.FirstOrDefaultAsync(v => v.idVaga == id);

                // If the job vacancy is not found, return 404 Not Found
                if (vaga == null)
                    return NotFound();

                // Update the status of the job vacancy to "Suspended"
                vaga.situacaoVaga = "Suspended";

                // Save the changes to the database
                await _context.SaveChangesAsync();

                return Ok("Job vacancy suspended successfully.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }












    }
}
