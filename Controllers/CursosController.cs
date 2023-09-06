using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;
using UIJobsAPI.Services.Candidatos;
using UIJobsAPI.Services.Cursos;
using UIJobsAPI.Services.Interfaces;

namespace UIJobsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursosController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursosController(ICursoService cursoService)
        {
            _cursoService = cursoService;
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

    }
}
