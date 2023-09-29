using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UijobsApi.DAL.Repositories.Cursos;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;
using UIJobsAPI.Services.Candidatos;
using UIJobsAPI.Services.Cursos;
using UIJobsAPI.Services.Interfaces;

namespace UIJobsAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CursosController : ControllerBase
    {
        private readonly ICursoService _cursoService;
        private readonly ICursoRepository _cursoRepository;
        private readonly DataContext _context;

        public CursosController(ICursoService cursoService, ICursoRepository cursoRepository, DataContext context)
        {
            _cursoService = cursoService;
            _cursoRepository = cursoRepository;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                Curso curso = await _cursoService.GetCursoByIdAsync(id);
                return Ok(curso);
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
                IEnumerable<Curso> listaCursos = await _cursoService.GetAllCursosAsync();
                return Ok(listaCursos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCursoAsync([FromBody] Curso novoCurso)
        {
            try
            {
                Curso curso = await _cursoService.AddCursoAsync(novoCurso);
                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            try
            {
                await _cursoService.DeleteCursoByIdAsync(id);
                return NoContent(); // Retorna uma resposta 204 No Content após a exclusão bem-sucedida.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna um StatusCode 400 Bad Request em caso de erro.
            }
        }




    }
}
