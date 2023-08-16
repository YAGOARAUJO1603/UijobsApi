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

    public class BeneficiosController : ControllerBase
    {

        private readonly DataContext _context;

        public BeneficiosController(DataContext context)
        {
            _context = context;
        }

        // Listar
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Beneficio> lista = await _context.Beneficios.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Consultar")]
        public async Task<IActionResult> Consultar(string nomeBeneficio)
        {
            try
            {
                // Consulta com base no curso
                List<Beneficio> lista = await _context.Beneficios.Where(form => form.nomeBeneficio.Contains(nomeBeneficio)).ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }












    }
}