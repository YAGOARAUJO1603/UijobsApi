using Microsoft.AspNetCore.Mvc;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;
using UijobsApi.Services.Vagas;
using UijobsApi.Services.VagasConhecimentos;

namespace UijobsApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VagaConhecimentoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IVagaConhecimentoService _vagaConhecimentoService;

        public VagaConhecimentoController(DataContext context, IVagaConhecimentoService vagaConhecimentoService)
        {
            _context = context;
            _vagaConhecimentoService = vagaConhecimentoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                VagaConhecimento vagaConhecimento = await _vagaConhecimentoService.GetVagaConhecimentoByIdAsync(id);
                return Ok(vagaConhecimento);
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
                IEnumerable<VagaConhecimento> listavagaConhe = await _vagaConhecimentoService.GetAllVagaConhecimentoAsync();
                return Ok(listavagaConhe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddVagaConhecimentoAsync(VagaConhecimento novaVagaConhecimento)
        {
            try
            {
                VagaConhecimento vagaConhecimento = await _vagaConhecimentoService.AddVagaConhecimentoAsync(novaVagaConhecimento);
                return Created("VagaConhecimento", vagaConhecimento);
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
                await _vagaConhecimentoService.DeleteVagaConhecimentoByIdAsync(id);
                return NoContent(); // Retorna uma resposta 204 No Content após a exclusão bem-sucedida.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna um StatusCode 400 Bad Request em caso de erro.
            }
        }
    }
}
