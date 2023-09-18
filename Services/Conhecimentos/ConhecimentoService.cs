using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UijobsApi.DAL.Repositories.Conhecimentos;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.Conhecimentos
{
    public class ConhecimentoService : IConhecimentoService
    {

        private readonly IConhecimentoRepository _conhecimentoRepository;

        public ConhecimentoService(IConhecimentoRepository idiomaRepository)
        {
            _conhecimentoRepository = idiomaRepository;
        }

        public async Task<Conhecimento> AddConhecimentoAsync(Conhecimento novoConhecimento)
        {
            var validationContext = new ValidationContext(novoConhecimento, null, null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(novoConhecimento, validationContext, validationResults, true))
            {
                // Se os dados não forem válidos, você pode lançar uma exceção ou tratar o erro de outra forma.
                throw new ValidationException("Os dados não são válidos.");
            }

            // Se os dados forem válidos, você pode continuar com a adição da escolaridade.
            return await _conhecimentoRepository.AddConhecimentoAsync(novoConhecimento);
        }


        public async Task DeleteConhecimentoByIdAsync(Conhecimento id)
        {
            // Você pode adicionar lógica de negócios adicional aqui, se necessário.

            // Chame o método de exclusão do repositório.
            await _conhecimentoRepository.DeleteConhecimentoByIdAsync(id);
        }

        public async Task<IEnumerable<Conhecimento>> GetAllConhecimentoAsync()
        {
            return await _conhecimentoRepository.GetAllConhecimentoAsync();
        }

        public async Task<Conhecimento> GetConhecimentoByIdAsync(int id)
        {
            Conhecimento conhecimento = await _conhecimentoRepository.GetConhecimentoByIdAsync(id);

            if (conhecimento == null)
            {
                throw new NotFoundException("Candidato");
            }

            return conhecimento;
        }
    }
}