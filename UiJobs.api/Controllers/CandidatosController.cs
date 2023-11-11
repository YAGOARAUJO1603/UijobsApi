using Microsoft.AspNetCore.Mvc;
using UijobsApi.DAL.Repositories.Candidatos;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;
using UIJobsAPI.Services.Interfaces;

namespace UIJobsAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CandidatosController : ControllerBase
    {
        private readonly ICandidatoService _candidatoService;

        public CandidatosController(ICandidatoService candidatoService)
        {
            _candidatoService = candidatoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                Candidato candidato = await _candidatoService.GetCandidatoByIdAsync(id);
                return Ok(candidato);
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
                IEnumerable<Candidato> listacandidatos = await _candidatoService.GetAllCandidatosAsync();
                return Ok(listacandidatos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddCandidatoAsync([FromBody] Candidato novoCandidato)
        {
            try
            {
                Candidato candidato = await _candidatoService.AddCandidatoAsync(novoCandidato);
                return Created("Candidato", candidato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidato(int id)
        {
            try
            {
                await _candidatoService.DeleteCandidatoByIdAsync(id);
                return NoContent(); // Retorna uma resposta 204 No Content após a exclusão bem-sucedida.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna um StatusCode 400 Bad Request em caso de erro.
            }
        }
    }
}
