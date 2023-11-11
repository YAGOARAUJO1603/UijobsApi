using Microsoft.AspNetCore.Mvc;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;
using UijobsApi.Services.EnderecoEmpresas;
using UijobsApi.DAL.Repositories.EnderecoEmpresas;

namespace UijobsApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EnderecoEmpresasController :ControllerBase
    {
        private readonly DataContext _context;
        private readonly IEnderecoEmpresaService _enderecoEmpresaService;

        public EnderecoEmpresasController(DataContext context, IEnderecoEmpresaService enderecoEmpresaService)
        { 
            _context = context;
            _enderecoEmpresaService = enderecoEmpresaService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                EnderecoEmpresa enderecoEmpresa = await _enderecoEmpresaService.GetEnderecoEmpresaByIdAsync(id);
                return Ok(enderecoEmpresa);
            }
            catch (BaseException ex)
            {
                // isso a gente controla
                return ex.GetResponse();
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddEnderecoEmpresaAsync(EnderecoEmpresa novoEnderecoEmpresa)
        {
            try
            {
                EnderecoEmpresa enderecoEmpresa = await _enderecoEmpresaService.AddEnderecoEmpresaAsync(novoEnderecoEmpresa);
                return Created("Endereço do Empresa criado", enderecoEmpresa);
                /*return Created("Endereco Candidato", enderecoCandidato);*/
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();

            }


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnderecoEmpresaAsync(int id)
        {
            try
            {
                await _enderecoEmpresaService.DeleteEnderecoEmpresaAsync(id);
                return NoContent(); // Retorna uma resposta 204 No Content após a exclusão bem-sucedida.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna um StatusCode 400 Bad Request em caso de erro.
            }
        }
    }
}
