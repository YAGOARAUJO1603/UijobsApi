using Microsoft.AspNetCore.Mvc;
using UIJobsAPI.Models;
using UIJobsAPI.Repositories.Candidatos;
using UIJobsAPI.Repositories.Cursos;
using UIJobsAPI.Repositories.Interfaces;

namespace UIJobsAPI.Services.Cursos
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<IEnumerable<Curso>> GetAllCursosAsync()
        {
            return await _cursoRepository.GetAllCursosAsync();
        }

        public async Task<Curso> AddCursoAsync([FromBody] Curso novoCurso)
        {
            return await _cursoRepository.AddCursoAsync(novoCurso);
        }
    }
}
