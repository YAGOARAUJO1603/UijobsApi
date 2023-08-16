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

    public class CursosVagasController : ControllerBase
    {
        private readonly DataContext _context;

        public CursosVagasController(DataContext context)
        {
            _context = context;
        }


        // Adicionar Formação Academica
        [HttpPost]
        public async Task<IActionResult> Add(CursoVaga CadastrarCursoVaga)
        {
            try
            {
                await _context.CursosVagas.AddAsync(CadastrarCursoVaga);
                await _context.SaveChangesAsync();

                return Ok(CadastrarCursoVaga.idVaga);
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
                CursoVaga cvRemover = await _context.CursosVagas.FirstOrDefaultAsync(cv => cv.idVaga == id);

                _context.CursosVagas.Remove(cvRemover);
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
                List<CursoVaga> lista = await _context.CursosVagas.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Consultar")]
        public async Task<IActionResult> Consultar(string idCursoVaga)
        {
            try
            {
                // Consulta com base no cursoVaga
                List<CursoVaga> lista = await _context.CursosVagas.Where(form => form.idCursoVaga.Contains(idCursoVaga)).ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


















    }
}