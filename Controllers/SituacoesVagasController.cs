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

    public class SituacoesVagasController : ControllerBase
    {

        private readonly DataContext _context;

        public SituacoesVagasController(DataContext context)
        {
            _context = context;
        }

        // Listar
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<SituacaoVaga> lista = await _context.SituacoesVagas.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Consultar")]
        public async Task<IActionResult> Consultar(string descricaoSituacao)
        {
            try
            {
                // Consulta com base no curso
                List<SituacaoVaga> lista = await _context.SituacoesVagas.Where(form => form.descricaoSituacao.Contains(descricaoSituacao)).ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }















    }
}