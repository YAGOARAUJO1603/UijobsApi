using Microsoft.AspNetCore.Mvc;
using UIJobsAPI.Data;
using UijobsApi.Services.Idiomas;
using UijobsApi.Services.Vagas;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class VagasController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IVagaService _vagaService;

        public VagasController(DataContext context, IVagaService vagaService)
        {
            _context = context;
            _vagaService = vagaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                Vaga vaga = await _vagaService.GetVagaByIdAsync(id);
                return Ok(vaga);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                IEnumerable<Vaga> listavaga = await _vagaService.GetAllVagaAsync();
                return Ok(listavaga);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddVagaAsync(Vaga novaVaga)
        {
            try
            {
                Vaga vaga = await _vagaService.AddVagaAsync(novaVaga);
                return Created("Vaga", vaga);
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
        public async Task<IActionResult> DeleteVaga(int id)
        {
            try
            {
                await _vagaService.DeleteVagaByIdAsync(id);
                return NoContent(); // Retorna uma resposta 204 No Content após a exclusão bem-sucedida.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna um StatusCode 400 Bad Request em caso de erro.
            }
        }
    }
}
