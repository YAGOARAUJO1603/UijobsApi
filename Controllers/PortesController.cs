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

    public class PortesController : ControllerBase
    {
        private readonly DataContext _context;

        public PortesController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Porte> lista = await _context.Portes.ToListAsync();
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
                List<Porte> lista = await _context.Portes.Where(form => form.descricao.Contains(descricao)).ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}