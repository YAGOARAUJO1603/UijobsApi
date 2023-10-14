using Microsoft.AspNetCore.Mvc;
using UijobsApi.DAL.Repositories.Cursos;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UIJobsAPI.Services.Cursos
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CursoService(ICursoRepository cursoRepository, IUnitOfWork unitOfWork)
        {
            _cursoRepository = cursoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Curso>> GetAllCursosAsync()
        {
            return await _cursoRepository.GetAllCursosAsync();
        }

        public async Task<Curso> AddCursoAsync([FromBody] Curso novoCurso)
        {
            Curso cursoExistente = await _cursoRepository.GetCursoByIdAsync(novoCurso.idCursos);
            if (cursoExistente != null && cursoExistente.Equals(novoCurso))
            {
                // bad request exception \/
                throw new Exception("Já existe um curso cadastrado com esse Id");
            }
            Curso curso = await _cursoRepository.AddCursoAsync(novoCurso);
            await _unitOfWork.SaveChangesAsync();
            return curso;
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

        public async Task DeleteCursoByIdAsync(int id)
        {
            Curso curso = await _cursoRepository.GetCursoByIdAsync(id);

            if (curso is null)
            {
                throw new NotFoundException("Curso com id não existe");
            }
            _cursoRepository.DeleteCursoByIdAsync(curso);
            await _unitOfWork.SaveChangesAsync();
        }

       
    }
}
