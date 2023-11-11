using Microsoft.AspNetCore.Mvc;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;
using UijobsApi.Services.Vagas;
using UijobsApi.Services.SituacoesVagas;

namespace UijobsApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class SituacaoVagaController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ISituacaoVagaService _situacaoVagaService;

        public SituacaoVagaController(DataContext context, ISituacaoVagaService situacaoVagaService)
        {
            _context = context;
            _situacaoVagaService = situacaoVagaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                SituacaoVaga situacaoVaga = await _situacaoVagaService.GetSituacaoVagaByIdAsync(id);
                return Ok(situacaoVaga);
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
                IEnumerable<SituacaoVaga> listaSituacaoVaga = await _situacaoVagaService.GetAllSituacaoVagaAsync();
                return Ok(listaSituacaoVaga);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
