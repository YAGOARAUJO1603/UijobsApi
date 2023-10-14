using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using UIJobsAPI.Data;
using UIJobsAPI.Models;
using UIJobsAPI.Models.Enuns;

namespace UijobsApi.DAL.Repositories.Cursos
{
    public class CursoRepository : ICursoRepository
    {
        private readonly DataContext _context;

        public CursoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Curso>> GetAllCursosAsync()
        {
            return await _context.Cursos.ToListAsync();
        }

        public async Task<Curso> AddCursoAsync([FromBody] Curso novoCurso)
        {
            await _context.Cursos.AddAsync(novoCurso);
            return novoCurso;
        }

        public async Task<Curso> GetCursoByIdAsync(int id)
        {
            return await _context.Cursos.FirstOrDefaultAsync(curso => curso.idCursos == id);
        }

        public async Task DeleteCursoByIdAsync(Curso curso)
        {
           _context.Cursos.Remove(curso);
        }
    }
}
