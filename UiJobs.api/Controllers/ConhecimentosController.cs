    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UijobsApi.DAL.Repositories.Conhecimentos;
using UijobsApi.Services.Conhecimentos;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ConhecimentosController : ControllerBase
    {
        private readonly IConhecimentoService _conhecimentoService;

        public ConhecimentosController(IConhecimentoService conhecimentoService)
        {
            _conhecimentoService = conhecimentoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                Conhecimento conhecimento = await _conhecimentoService.GetConhecimentoByIdAsync(id);
                return Ok(conhecimento);
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
                IEnumerable<Conhecimento> listaconhecimento = await _conhecimentoService.GetAllConhecimentoAsync();
                return Ok(listaconhecimento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddConhecimentoAsync(Conhecimento novoConhecimento)
        {
            try
            {
                Conhecimento conhecimento = await _conhecimentoService.AddConhecimentoAsync(novoConhecimento);
                return Created("Conhecimento", conhecimento);
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
        public async Task<IActionResult> DeleteConhecimento(int id)
        {
            try
            {
                await _conhecimentoService.DeleteConhecimentoByIdAsync(id);
                return NoContent(); // Retorna uma resposta 204 No Content após a exclusão bem-sucedida.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna um StatusCode 400 Bad Request em caso de erro.
            }
        }

    }
}