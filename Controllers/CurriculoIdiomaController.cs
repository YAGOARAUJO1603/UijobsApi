using Microsoft.AspNetCore.Mvc;
using UijobsApi.DAL.Repositories.CurriculosConhecimentos;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;
using UijobsApi.Services.CurriculosConhecimentos;
using UijobsApi.Services.CurriculosIdiomas;
using UijobsApi.DAL.Repositories.CurriculosIdiomas;

namespace UijobsApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CurriculoIdiomaController : ControllerBase
    {
        private readonly ICurriculoIdiomaService _curriculoIdiomaService;
        private readonly ICurriculoIdiomaRepository _curriculoIdiomaRepository;
        private readonly DataContext _context;

        public CurriculoIdiomaController(ICurriculoIdiomaService curriculoIdiomaService, ICurriculoIdiomaRepository curriculoIdiomaRepository, DataContext context)
        {
            _curriculoIdiomaService = curriculoIdiomaService;
            _curriculoIdiomaRepository = curriculoIdiomaRepository;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                CurriculoIdioma curriculoIdioma = await _curriculoIdiomaService.GetCurriculoIdiomasByIdAsync(id);
                return Ok(curriculoIdioma);
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
                IEnumerable<CurriculoIdioma> listaCurriculoIdiomas = await _curriculoIdiomaService.GetAllCurriculoIdiomasAsync();
                return Ok(listaCurriculoIdiomas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCurriculoIdiomaAsync(CurriculoIdioma novoCurriculoIdioma)
        {
            try
            {
                CurriculoIdioma curriculoIdioma = await _curriculoIdiomaService.AddCurriculoIdiomaAsync(novoCurriculoIdioma);
                return Ok(curriculoIdioma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurriculoIdioma(int id)
        {
            try
            {
                await _curriculoIdiomaService.DeleteCurriculoIdiomaByIdAsync(id);
                return NoContent(); // Retorna uma resposta 204 No Content após a exclusão bem-sucedida.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna um StatusCode 400 Bad Request em caso de erro.
            }
        }
    }
}
