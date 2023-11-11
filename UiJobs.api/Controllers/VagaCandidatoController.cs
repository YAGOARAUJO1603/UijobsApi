using Microsoft.AspNetCore.Mvc;
using UijobsApi.DAL.Repositories.CurriculosIdiomas;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;
using UijobsApi.Services.CurriculosIdiomas;
using UijobsApi.Services.VagasCandidatos;
using UijobsApi.DAL.Repositories.VagasCandidatos;

namespace UijobsApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VagaCandidatoController : ControllerBase
    {
        private readonly IVagaCandidatoService _vagaCandidatoService;
        private readonly IVagaCandidatoRepository _vagaCandidatoRepository;
        private readonly DataContext _context;

        public VagaCandidatoController(IVagaCandidatoService vagaCandidatoService, IVagaCandidatoRepository vagaCandidatoRepository, DataContext context)
        {
            _vagaCandidatoService = vagaCandidatoService;
            _vagaCandidatoRepository = vagaCandidatoRepository;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                VagaCandidato vagaCandidato = await _vagaCandidatoService.GetVagaCandidatoByIdAsync(id);
                return Ok(vagaCandidato);
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
                IEnumerable<VagaCandidato> listaVagaCandidato = await _vagaCandidatoService.GetAllVagaCandidatoAsync();
                return Ok(listaVagaCandidato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddVagaCandidatoAsync(VagaCandidato novaVagaCandidato)
        {
            try
            {
                VagaCandidato vagaCandidato = await _vagaCandidatoService.AddVagaCandidatoAsync(novaVagaCandidato);
                return Ok(vagaCandidato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVagaCandidato(int id)
        {
            try
            {
                await _vagaCandidatoService.DeleteVagaCandidatoByIdAsync(id);
                return NoContent(); // Retorna uma resposta 204 No Content após a exclusão bem-sucedida.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna um StatusCode 400 Bad Request em caso de erro.
            }
        }
    }
}
