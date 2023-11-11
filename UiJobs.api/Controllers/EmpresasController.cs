using Microsoft.AspNetCore.Mvc;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;
using UijobsApi.DAL.Repositories.Empresas;
using UijobsApi.Services.Empresas;

namespace UijobsApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class EmpresasController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IEmpresaService _empresaService;
        public EmpresasController(DataContext context, IEmpresaRepository empresaRepository, IEmpresaService empresaService)
        {
            _context = context;
            _empresaRepository = empresaRepository;
            _empresaService = empresaService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                Empresa empresa = await _empresaService.GetEmpresaByIdAsync(id);
                return Ok(empresa);
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
        [HttpPost]
        public async Task<IActionResult> AddEmpresaAsync(Empresa novaEmpresa)
        {
            try
            {
                Empresa empresa = await _empresaService.AddEmpresaAsync(novaEmpresa);
                return Created("Empresa", empresa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            try
            {
                await _empresaService.DeleteEmpresaAsync(id);
                return NoContent(); // Retorna uma resposta 204 No Content após a exclusão bem-sucedida.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna um StatusCode 400 Bad Request em caso de erro.
            }
        }
    }
}
