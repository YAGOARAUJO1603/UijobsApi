using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UijobsApi.Repositories.Escolaridades;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.Escolaridades
{
    public class EscolaridadeService : IEscolaridadeService
    {
        private readonly IEscolaridadeRepository _escolaridadeRepository;

        public EscolaridadeService(IEscolaridadeRepository escolaridadeRepository)
        {
            _escolaridadeRepository = escolaridadeRepository;
        }



        public async Task<Escolaridade> AddEscolaridadeAsync(Escolaridade novaEscolaridade)
        {
            var validationContext = new ValidationContext(novaEscolaridade, null, null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(novaEscolaridade, validationContext, validationResults, true))
            {
                // Se os dados não forem válidos, você pode lançar uma exceção ou tratar o erro de outra forma.
                throw new ValidationException("Os dados da escolaridade não são válidos.");
            }

            // Se os dados forem válidos, você pode continuar com a adição da escolaridade.
            return await _escolaridadeRepository.AddEscolaridadeAsync(novaEscolaridade);
        }

        public async Task DeleteEscolaridadeByIdAsync(int id)
        {
            // Você pode adicionar lógica de negócios adicional aqui, se necessário.

            // Chame o método de exclusão do repositório.
            await _escolaridadeRepository.DeleteEscolaridadeByIdAsync(id);  
            
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