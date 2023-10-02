using Microsoft.AspNetCore.Mvc;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;
using UijobsApi.Services.SituacoesVagas;
using UijobsApi.Services.Portes;

namespace UijobsApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PortesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IPorteService _porteService;

        public PortesController(DataContext context, IPorteService porteService)
        {
            _context = context;
            _porteService = porteService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                Porte porte = await _porteService.GetPorteByIdAsync(id);
                return Ok(porte);
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
                IEnumerable<Porte> listaPorte= await _porteService.GetAllPorteAsync();
                return Ok(listaPorte);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
