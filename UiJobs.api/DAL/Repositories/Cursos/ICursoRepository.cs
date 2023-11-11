using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.Cursos
{
    public interface ICursoRepository
    {
        public Task<IEnumerable<Curso>> GetAllCursosAsync();

        public Task<Curso> GetCursoByIdAsync(int id);
        public Task<Curso> AddCursoAsync(Curso novoCurso);

        public Task DeleteCursoByIdAsync(Curso curso);
    }
}
