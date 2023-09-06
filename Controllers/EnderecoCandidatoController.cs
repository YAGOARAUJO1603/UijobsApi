using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UijobsApi.Repositories.EnderecoCandidatos;
using UijobsApi.Services.EnderecoCandidatos;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;
using UIJobsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using UIJobsAPI.Repositories.Interfaces;
using UIJobsAPI.Services.Candidatos;

namespace UijobsApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EnderecoCandidatoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IEnderecoCandidatoService _enderecoCandidatoService;
        private readonly IEnderecoCandidatoRepository _enderecoCandidatoRepository;

        public EnderecoCandidatoController(DataContext context, IEnderecoCandidatoService enderecoCandidatoService, IEnderecoCandidatoRepository enderecoCandidatoRepository)
        {
            _context = context;
            _enderecoCandidatoService = enderecoCandidatoService;
            _enderecoCandidatoRepository = enderecoCandidatoRepository;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                EnderecoCandidato enderecoCandidato = await _enderecoCandidatoService.GetEnderecoCandidatosByIdAsync(id);
                return Ok(enderecoCandidato);
            }
            catch (BaseException ex)
            {
                // isso a gente controla
                return ex.GetResponse();
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> AddEnderecoCandidatoAsync( EnderecoCandidato novoEnderecoCandidato)
        {
            try
            {
                EnderecoCandidato enderecoCandidato = await _enderecoCandidatoService.AddEnderecoCandidatosAsync(novoEnderecoCandidato);
                return Created("Endereço do Candidato criado", enderecoCandidato);
                /*return Created("Endereco Candidato", enderecoCandidato);*/
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnderecoCandidatoAsync(int id)
        {
            try
            {
                await _enderecoCandidatoRepository.DeleteEnderecoCandidatoAsync(id);
                return NoContent(); // Retorna uma resposta 204 No Content após a exclusão bem-sucedida.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna um StatusCode 400 Bad Request em caso de erro.
            }
        }



    }
}