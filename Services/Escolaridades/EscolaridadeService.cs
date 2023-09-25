using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UijobsApi.DAL.Repositories.Escolaridades;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.Escolaridades
{
    public class EscolaridadeService : IEscolaridadeService
    {
        private readonly IEscolaridadeRepository _escolaridadeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EscolaridadeService(IEscolaridadeRepository escolaridadeRepository, IUnitOfWork unitOfWork)
        {
            _escolaridadeRepository = escolaridadeRepository;
            _unitOfWork = unitOfWork;
        }



        public async Task<Escolaridade> AddEscolaridadeAsync(Escolaridade novaEscolaridade)
        {
            Escolaridade escolaridadeExistente = await _escolaridadeRepository.GetEscolaridadeByIdAsync(novaEscolaridade.idEscolaridade);
            if (escolaridadeExistente != null && escolaridadeExistente.Equals(novaEscolaridade))
            {
                // bad request exception \/
                throw new Exception("Já existe uma escolaridade cadastrada com esse Id.");
            }
            Escolaridade escolaridade = await _escolaridadeRepository.AddEscolaridadeAsync(novaEscolaridade);
            await _unitOfWork.SaveChangesAsync();
            return escolaridade;
        }

        public async Task DeleteEscolaridadeByIdAsync(int id)
        {
            Escolaridade escolaridade = await _escolaridadeRepository.GetEscolaridadeByIdAsync(id);

            if (escolaridade is null)
            {
                throw new NotFoundException("Escolaridade com id não existe");
            }
            _escolaridadeRepository.DeleteEscolaridadeByIdAsync(escolaridade);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<IEnumerable<Escolaridade>> GetAllEscolaridadeAsync()
        {
            return await _escolaridadeRepository.GetAllEscolaridadeAsync();
        }

        public async Task<Escolaridade> GetEscolaridadeByIdAsync(int id)
        {
            Escolaridade escolaridade = await _escolaridadeRepository.GetEscolaridadeByIdAsync(id);

            if (escolaridade == null)
            {
                throw new NotFoundException("Candidato");
            }

            return escolaridade;
        }
    }
}