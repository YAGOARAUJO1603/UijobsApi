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
    
    public class GraduacoesController : ControllerBase
    {
        private readonly DataContext _context;

        public GraduacoesController(DataContext context)
        {
            _context = context;
        }

        // Listar
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Graduacao> lista = await _context.Graduacoes.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Consultar")]
        public async Task<IActionResult> Consultar(string nomeGraduacao)
        {
            try
            {
                // Consulta com base no curso
                List<Graduacao> lista = await _context.Graduacoes.Where(form => form.nomeGraduacao.Contains(nomeGraduacao)).ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        
    }
}