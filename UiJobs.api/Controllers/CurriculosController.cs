using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UijobsApi.DAL.Repositories.Curriculos;
using UijobsApi.Services.Curriculos;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CurriculosController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly ICurriculoService _curriculoService;
        private readonly ICurriculoRepository _curriculoRepository;

        public CurriculosController(DataContext context, ICurriculoService curriculoService, ICurriculoRepository curriculoRepository)
        {
            _context = context;
            _curriculoService = curriculoService;
            _curriculoRepository = curriculoRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                Curriculo curriculo = await _curriculoService.GetCurriculoByIdAsync(id);
                return Ok(curriculo);
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

        [HttpPost]
        public async Task<IActionResult> AddCurriculoAsync(Curriculo novoCurriculo)
        {
            try
            {
                Curriculo curriculo = await _curriculoService.AddCurriculoAsync(novoCurriculo);
                return Created("Curriculo", curriculo);
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
        public async Task<IActionResult> DeleteCurriculo(int id)
        {
            try
            {
                await _curriculoService.DeleteCurriculoByIdAsync(id);
                return NoContent(); // Retorna uma resposta 204 No Content após a exclusão bem-sucedida.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna um StatusCode 400 Bad Request em caso de erro.
            }
        }


    }
}