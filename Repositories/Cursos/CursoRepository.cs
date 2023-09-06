using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using UIJobsAPI.Data;
using UIJobsAPI.Models;
using UIJobsAPI.Models.Enuns;

namespace UIJobsAPI.Repositories.Cursos
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
            IEnumerable<Curso> cursos = await _context.Cursos.ToListAsync();
            return cursos;
        }

        public async Task<Curso> AddCursoAsync([FromBody] Curso novoCurso)
        {

            await _context.AddAsync(novoCurso);
            await _context.SaveChangesAsync();
            return novoCurso;
        }

    }
}
