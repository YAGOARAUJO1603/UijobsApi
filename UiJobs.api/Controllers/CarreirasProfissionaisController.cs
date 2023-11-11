using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UijobsApi.DAL.Repositories.CarreirasProfissionais;
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
                await _carreiraProfissionalServices.DeleteCarreiraProfissionalAsync(id);
                return NoContent(); // Retorna uma resposta 204 No Content após a exclusão bem-sucedida.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna um StatusCode 400 Bad Request em caso de erro.
            }
        }

    }
}