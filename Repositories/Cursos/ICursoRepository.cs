using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UIJobsAPI.Repositories.Cursos
{
    public interface ICursoRepository
    {
        public Task<IEnumerable<Curso>> GetAllCursosAsync();
        public Task<Curso> AddCursoAsync([FromBody] Curso novoCurso);
    }
}
