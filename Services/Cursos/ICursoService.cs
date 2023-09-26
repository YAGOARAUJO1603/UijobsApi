using Microsoft.AspNetCore.Mvc;
using UIJobsAPI.Models;

namespace UIJobsAPI.Services.Cursos
{
    public interface ICursoService
    {
        public Task<IEnumerable<Curso>> GetAllCursosAsync();

        public Task<Curso> GetCursoByIdAsync(int id);
        public Task<Curso> AddCursoAsync([FromBody] Curso novoCurso);

        public Task DeleteCursoByIdAsync(int id);
    }
}
