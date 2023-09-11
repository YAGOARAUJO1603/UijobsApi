using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using UijobsApi.Repositories.EnderecoCandidatos;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.EnderecoCandidatos
{
    public class EnderecoCandidatoService : IEnderecoCandidatoService
    {

        private readonly IEnderecoCandidatoRepository _enderecoCandidatoRepository;

        public EnderecoCandidatoService(IEnderecoCandidatoRepository enderecoCandidatoRepository)
        {
            _enderecoCandidatoRepository = enderecoCandidatoRepository;
        }


        public async Task<EnderecoCandidato> AddEnderecoCandidatosAsync(EnderecoCandidato novoEnderecoCandidato)
        {
            // Realize a validação usando DataAnnotations

            var validationContext = new ValidationContext(novoEnderecoCandidato, null, null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(novoEnderecoCandidato, validationContext, validationResults, true))
            {
                // Se os dados não forem válidos, você pode lançar uma exceção ou tratar o erro de outra forma.
                throw new ValidationException("Os dados do endereço não são válidos.");
            }

            // Se os dados forem válidos, você pode continuar com a adição do endereço.
            return await _enderecoCandidatoRepository.AddEnderecoCandidatosAsync(novoEnderecoCandidato);
        }

        public async Task DeleteEnderecoCandidatoByIdAsync(int id)
        {
            // Você pode adicionar lógica de negócios adicional aqui, se necessário.

            // Chame o método de exclusão do repositório.
            await _enderecoCandidatoRepository.DeleteEnderecoCandidatoAsync(id);
        }

        public async Task<EnderecoCandidato> GetEnderecoCandidatosByIdAsync(int id)
        {
            EnderecoCandidato enderecoCandidato = await _enderecoCandidatoRepository.GetEnderecoCandidatosByIdAsync(id);

            if (enderecoCandidato == null)
            {
                throw new NotFoundException("Endereco Candidato");
            }

            return enderecoCandidato;
        }
    }
}