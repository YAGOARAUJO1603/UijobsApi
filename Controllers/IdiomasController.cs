using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UijobsApi.DAL.Repositories.Idiomas;
using UijobsApi.Services.Idiomas;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class IdiomasController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IIdiomaService _idiomaService;

        public IdiomasController(DataContext context, IIdiomaService idiomaService)
        {
            _context = context;
            _idiomaService = idiomaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                Idioma idioma = await _idiomaService.GetIdiomaByIdAsync(id);
                return Ok(idioma);
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
                IEnumerable<Idioma> listaidioma = await _idiomaService.GetAllIdiomaAsync();
                return Ok(listaidioma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddIdiomaAsync([FromBody] Idioma novoIdioma)
        {
            try
            {
                Idioma idioma = await _idiomaService.AddIdiomaAsync(novoIdioma);
                return Created("Idioma", idioma);
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
        public async Task<IActionResult> DeleteIdioma(int id)
        {
            try
            {
                await _idiomaService.DeleteIdiomaByIdAsync(id);
                return NoContent(); // Retorna uma resposta 204 No Content após a exclusão bem-sucedida.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna um StatusCode 400 Bad Request em caso de erro.
            }
        }
    }
}