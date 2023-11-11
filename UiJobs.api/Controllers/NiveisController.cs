using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UijobsApi.Services.Niveis;
using UIJobsAPI.Data;
using UIJobsAPI.Models;
using UIJobsAPI.Exceptions;
using UijobsApi.DAL.Repositories.Niveis;
using UIJobsAPI.Models.Enuns;

namespace UijobsApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NiveisController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly INivelService _nivelService;
        private readonly INivelRepository _nivelRepository;

        public NiveisController(DataContext context, INivelService nivelService, INivelRepository nivelRepository)
        {
            _context = context;
            _nivelService = nivelService;
            _nivelRepository = nivelRepository;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                IEnumerable<Nivel> listanivel = await _nivelService.GetAllNivelAsync();
                return Ok(listanivel);
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
                

                Nivel nivel = await _nivelService.GetNivelByIdAsync(id);

                return Ok(nivel);
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


    }
}