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

    public class NiveisController : ControllerBase
    {

        private readonly DataContext _context;

        public NiveisController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Nivel> lista = await _context.Niveis.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Consultar")]
        public async Task<IActionResult> Consultar(string descricao)
        {
            try
            {
                // Consulta a carreira com base no curso
                List<Nivel> lista = await _context.Niveis.Where(form => form.descricao.Contains(descricao)).ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }














    }
}