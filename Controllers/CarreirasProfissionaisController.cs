using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UijobsApi.Repositories.CarreirasProfissionais;
using UijobsApi.Services.CarreirasProfissionais;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class CarreirasProfissionaisController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly ICarreiraProfissionalRepository _carreiraProfissionalRepository;
        private readonly ICarreiraProfissionalServices _carreiraProfissionalServices;
        public CarreirasProfissionaisController(DataContext context, ICarreiraProfissionalRepository carreiraProfissionalRepository, ICarreiraProfissionalServices carreiraProfissionalServices)
        {
            _context = context;
            _carreiraProfissionalRepository = carreiraProfissionalRepository;
            _carreiraProfissionalServices = carreiraProfissionalServices;
        }



        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                IEnumerable<CarreiraProfissional> listacarreiraProfissional = await _carreiraProfissionalServices.GetCarreiraProfissionalByIdAsync();
                return Ok(listacarreiraProfissional);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                CarreiraProfissional carreiraProfissional = await _carreiraProfissionalServices.GetCarreiraProfissionalByIdAsync(id);
                return Ok(carreiraProfissional);
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
        public async Task<IActionResult> AddCarreiraProfissionalAsync(CarreiraProfissional novaCarreiraProfissional)
        {
            try
            {
                CarreiraProfissional carreiraProfissional = await _carreiraProfissionalServices.AddCarreiraProfissionalAsync(novaCarreiraProfissional);
                return Created("Carreira Profissional", carreiraProfissional);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarreiraProfissional(int id)
        {
            try
            {
                await _carreiraProfissionalRepository.DeleteCarreiraProfissionalAsync(id);
                return NoContent(); // Retorna uma resposta 204 No Content após a exclusão bem-sucedida.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna um StatusCode 400 Bad Request em caso de erro.
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CarreiraProfissional>> PutCarreiraProfissionalAsync(int id, CarreiraProfissional carreiraProfissionalAtualizada)
        {
            try
            {
                var carreiraProfissionalAtualizadaResult = await _carreiraProfissionalServices.PutCarreiraProfissionalAsync(id, carreiraProfissionalAtualizada);

                return carreiraProfissionalAtualizadaResult != null
                    ? Ok(carreiraProfissionalAtualizadaResult)
                    : NotFound("A carreira profissional com o ID fornecido não foi encontrada.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro interno no servidor.");
            }
        }






    }
}