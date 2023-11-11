using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using UijobsApi.DAL.Repositories.Candidatos;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;
using UIJobsAPI.Services.Interfaces;

namespace UIJobsAPI.Services.Candidatos
{
    public class CandidatoService : ICandidatoService
    {
        private readonly ICandidatoRepository _candidatoRepository;
        private readonly IUnitOfWork _unitOfWork;
        

        public CandidatoService(ICandidatoRepository candidatoRepository, IUnitOfWork unitOfWork)
        {
            _candidatoRepository = candidatoRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Candidato>> GetAllCandidatosAsync()
        {
            return await _candidatoRepository.GetAllCandidatosAsync();
        }

        public async Task<Candidato> GetCandidatoByIdAsync(int id)
        {
            Candidato candidato = await _candidatoRepository.GetCandidatoByIdAsync(id);

            if (candidato == null)
            {
                throw new NotFoundException("Candidato");
            }

            return candidato;
        }

        public async Task<Candidato> AddCandidatoAsync(Candidato novoCandidato)
        {
            Candidato candidatoExistente = await _candidatoRepository.GetCandidatoByEmailAsync(novoCandidato.email);
            if (candidatoExistente != null && candidatoExistente.Equals(novoCandidato))
            {
                // bad request exception \/
                throw new Exception("Já existe um candidato com esse email.");
            } 

 

            Candidato candidato = await _candidatoRepository.AddCandidatoAsync(novoCandidato);
            await _unitOfWork.SaveChangesAsync();
            return candidato;
        }

        public async Task DeleteCandidatoByIdAsync(int id)
        {

            Candidato candidato = await _candidatoRepository.GetCandidatoByIdAsync(id);

           if(candidato is null)
            {
                throw new NotFoundException("Candidato com id não existe");
            }
            _candidatoRepository.DeleteCandidatoByIdAsync(candidato);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
