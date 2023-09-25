using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UijobsApi.DAL.Repositories.FormacoesAcademicas;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.FormacoesAcademicas
{
    public class FormacaoAcademicaService : IFormacaoAcademicaService
    {

        private readonly IFormacaoAcademicaRepository _formacaoAcademicaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FormacaoAcademicaService(IFormacaoAcademicaRepository formacaoAcademicaRepository, IUnitOfWork unitOfWork)
        {
            _formacaoAcademicaRepository = formacaoAcademicaRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<FormacaoAcademica> AddFormacoesAcademicasAsync(FormacaoAcademica novaFormacaoAcademica)
        {
            FormacaoAcademica formacaoExistente = await _formacaoAcademicaRepository.GetFormacoesAcademicasByIdAsync(novaFormacaoAcademica.idFormacaoAcademica);
            if (formacaoExistente != null && formacaoExistente.Equals(novaFormacaoAcademica))
            {
                // bad request exception \/
                throw new Exception("Já existe um Id cadastrada com essa formação.");
            }
            FormacaoAcademica formacaoAcademica = await _formacaoAcademicaRepository.AddFormacoesAcademicasAsync(novaFormacaoAcademica);
            await _unitOfWork.SaveChangesAsync();
            return formacaoAcademica;
        }

        public async Task DeleteFormacoesAcademicasByIdAsync(int id)
        {
            FormacaoAcademica formacaoAcademica = await _formacaoAcademicaRepository.GetFormacoesAcademicasByIdAsync(id);

            if (formacaoAcademica is null)
            {
                throw new NotFoundException("Formação academica com id não existe");
            }
            _formacaoAcademicaRepository.DeleteFormacoesAcademicasByIdAsync(formacaoAcademica);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<FormacaoAcademica>> GetAllFormacoesAcademicasAsync()
        {
            return await _formacaoAcademicaRepository.GetAllFormacoesAcademicasAsync();
        }

        public async Task<FormacaoAcademica> GetFormacoesAcademicasByIdAsync(int id)
        {
            FormacaoAcademica formacaoAcademica = await _formacaoAcademicaRepository.GetFormacoesAcademicasByIdAsync(id);

            if (formacaoAcademica == null)
            {
                throw new NotFoundException("Candidato");
            }

            return formacaoAcademica;
        }
    }
}