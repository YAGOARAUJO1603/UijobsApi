using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UijobsApi.DAL.Repositories.Curriculos;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.Curriculos
{
    public class CurriculoService : ICurriculoService
    {
        private readonly ICurriculoRepository _curriculoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CurriculoService(ICurriculoRepository idiomaRepository, IUnitOfWork unitOfWork)
        {
            _curriculoRepository = idiomaRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Curriculo> AddCurriculoAsync(Curriculo novoCurriculo)
        {
            Curriculo curriculoExistente = await _curriculoRepository.GetCurriculoByIdAsync(novoCurriculo.idCurriculo);
            if (curriculoExistente != null && curriculoExistente.Equals(novoCurriculo))
            {
                // bad request exception \/
                throw new Exception("Já existe um candidato com esse curriculo cadastrado.");
            }
            Curriculo curriculo = await _curriculoRepository.AddCurriculoAsync(novoCurriculo);
            await _unitOfWork.SaveChangesAsync();
            return curriculo;
        }

        public async Task DeleteCurriculoByIdAsync(int id)
        {
            Curriculo curriculo = await _curriculoRepository.GetCurriculoByIdAsync(id);

            if (curriculo is null)
            {
                throw new NotFoundException("Curriculo com id não existe");
            }
            _curriculoRepository.DeleteCurriculoByIdAsync(curriculo);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Curriculo> GetCurriculoByIdAsync(int id)
        {
            Curriculo curriculo = await _curriculoRepository.GetCurriculoByIdAsync(id);

            if (curriculo == null)
            {
                throw new NotFoundException("Candidato");
            }

            return curriculo;
        }
    }
}