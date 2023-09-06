using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;
using UIJobsAPI.Repositories.Interfaces;
using UIJobsAPI.Services.Interfaces;

namespace UIJobsAPI.Services.Candidatos
{
    public class CandidatoService : ICandidatoService
    {
        private readonly ICandidatoRepository _candidatoRepository;
        

        public CandidatoService(ICandidatoRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
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
            return candidato;
        }

        public async Task DeleteCandidatoByIdAsync(int id)
        {
            // Você pode adicionar lógica de negócios adicional aqui, se necessário.

            // Chame o método de exclusão do repositório.
            await _candidatoRepository.DeleteCandidatoByIdAsync(id);           
        }
    }
}
