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
    
    public class CursosController : ControllerBase
    {

        private readonly DataContext _context;

        public CursosController(DataContext context)
        {
            _context = context;
        }

        // Listar
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Curso> lista = await _context.Cursos.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Consultar")]
        public async Task<IActionResult> Consultar(string nomeCurso)
        {
            try
            {
                // Consulta com base no curso
                List<Curso> lista = await _context.Cursos.Where(form => form.nomeCurso.Contains(nomeCurso)).ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }









    }
}