using Microsoft.AspNetCore.Mvc;
using UijobsApi.Services.Beneficios;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BeneficiosController : ControllerBase
    {
        private readonly IBeneficioService _beneficioService;
        private readonly DataContext _context;

        public BeneficiosController(IBeneficioService beneficioService, DataContext context)
        {
            _beneficioService = beneficioService;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                Beneficio beneficio = await _beneficioService.GetBeneficioByIdAsync(id);
                return Ok(beneficio);
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
                IEnumerable<Beneficio> listaBeneficios = await _beneficioService.GetAllBeneficioAsync();
                return Ok(listaBeneficios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCBeneficioAsync(Beneficio novoBeneficio)
        {
            try
            {
                Beneficio beneficio = await _beneficioService.AddBeneficioAsync(novoBeneficio);
                return Ok(beneficio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBenficio(int id)
        {
            try
            {
                await _beneficioService.DeleteBeneficioByIdAsync(id);
                return NoContent(); // Retorna uma resposta 204 No Content após a exclusão bem-sucedida.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna um StatusCode 400 Bad Request em caso de erro.
            }
        }
    }
}
