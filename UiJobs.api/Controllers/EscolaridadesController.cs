using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UijobsApi.DAL.Repositories.Escolaridades;
using UijobsApi.Services.Escolaridades;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class EscolaridadesController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly IEscolaridadeService _escolaridadeService;
        private readonly IEscolaridadeRepository _escolaridadeRepository;

        public EscolaridadesController(DataContext context, IEscolaridadeService escolaridadeService, IEscolaridadeRepository escolaridadeRepository)
        {
            _context = context;
            _escolaridadeService = escolaridadeService;
            _escolaridadeRepository = escolaridadeRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                Escolaridade escolaridade = await _escolaridadeService.GetEscolaridadeByIdAsync(id);
                return Ok(escolaridade);
            }
            catch (BaseException ex)
            {
                // isso a gente controla
                return ex.GetResponse();
            }
            catch (Exception ex)
            {
                // isso foge da gente
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                IEnumerable<Escolaridade> listaescolaridade = await _escolaridadeService.GetAllEscolaridadeAsync();
                return Ok(listaescolaridade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEscolaridadeAsync([FromBody] Escolaridade novaEscolaridade)
        {
            try
            {
                Escolaridade escolaridade = await _escolaridadeService.AddEscolaridadeAsync(novaEscolaridade);
                return Created("Escolaridade", escolaridade);
            }
           catch (BaseException ex)
            {
                // isso a gente controla
                return ex.GetResponse();
            }
            catch (Exception ex)
            {
                // isso foge da gente
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEscolaridade(int id)
        {
            try
            {
                await _escolaridadeService.DeleteEscolaridadeByIdAsync(id);
                return NoContent(); // Retorna uma resposta 204 No Content após a exclusão bem-sucedida.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna um StatusCode 400 Bad Request em caso de erro.
            }
        }






    }
}