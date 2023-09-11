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

        public async Task<Curso> GetCursoByIdAsync(int id)
        {
            Curso curso = await _context.Cursos.FirstOrDefaultAsync(curso => curso.idCurso == id);
            return curso;
        }

        public async Task DeleteCursoByIdAsync(int id)
        {
            var cursoParaExcluir = await _context.Cursos.FirstOrDefaultAsync(curso => curso.idCurso == id);

            if (cursoParaExcluir != null)
            {
                _context.Cursos.Remove(cursoParaExcluir);
                await _context.SaveChangesAsync();
            }
        }
    }
}
