using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UijobsApi.DAL.Repositories.FormacoesAcademicas;
using UijobsApi.Services.FormacoesAcademicas;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FormacoesAcademicasController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly IFormacaoAcademicaService _formacaoAcademicaService;
        private readonly IFormacaoAcademicaRepository _formacaoAcademicaRepository;

        public FormacoesAcademicasController(DataContext context, IFormacaoAcademicaService formacaoAcademicaService, IFormacaoAcademicaRepository formacaoAcademicaRepository)
        {
            _context = context;
            _formacaoAcademicaService = formacaoAcademicaService;
            _formacaoAcademicaRepository = formacaoAcademicaRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                FormacaoAcademica formacaoAcademica = await _formacaoAcademicaService.GetFormacoesAcademicasByIdAsync(id);
                return Ok(formacaoAcademica);
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
                IEnumerable<FormacaoAcademica> listaformacaoAcademica = await _formacaoAcademicaService.GetAllFormacoesAcademicasAsync();
                return Ok(listaformacaoAcademica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddFormacoesAcademicasAsync(FormacaoAcademica novaFormacaoAcademica)
        {
            try
            {
                FormacaoAcademica formacaoAcademica = await _formacaoAcademicaService.AddFormacoesAcademicasAsync(novaFormacaoAcademica);
                return Created("Formação Academica", formacaoAcademica);
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
        public async Task<IActionResult> DeleteFormacaoAcademica(int id)
        {
            try
            {
                await _formacaoAcademicaService.DeleteFormacoesAcademicasByIdAsync(id);
                return NoContent(); // Retorna uma resposta 204 No Content após a exclusão bem-sucedida.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna um StatusCode 400 Bad Request em caso de erro.
            }
        }











    }
}