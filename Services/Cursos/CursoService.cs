using Microsoft.AspNetCore.Mvc;
using UijobsApi.DAL.Repositories.Cursos;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

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


        public async Task<Curso> GetCursoByIdAsync(int id)
        {
            Curso curso = await _cursoRepository.GetCursoByIdAsync(id);

            if (curso == null)
            {
                throw new NotFoundException("Candidato");
            }

            return curso;
        }

        public async Task DeleteCursoByIdAsync(Curso id)
        {
            // Você pode adicionar lógica de negócios adicional aqui, se necessário.

            // Chame o método de exclusão do repositório.
            await _cursoRepository.DeleteCursoByIdAsync(id);
        }

       
    }
}
