using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UijobsApi.Repositories.Curriculos;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.Curriculos
{
    public class CurriculoService : ICurriculoService
    {
        private readonly ICurriculoRepository _curriculoRepository;

        public CurriculoService(ICurriculoRepository idiomaRepository)
        {
            _curriculoRepository = idiomaRepository;
        }


        public async Task<Curriculo> AddCurriculoAsync(Curriculo novoCurriculo)
        {
            var validationContext = new ValidationContext(novoCurriculo, null, null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(novoCurriculo, validationContext, validationResults, true))
            {
                // Se os dados não forem válidos, você pode lançar uma exceção ou tratar o erro de outra forma.
                throw new ValidationException("Os dados não são válidos.");
            }

            // Se os dados forem válidos, você pode continuar com a adição da escolaridade.
            return await _curriculoRepository.AddCurriculoAsync(novoCurriculo);
        }

        public async Task DeleteCurriculoByIdAsync(int id)
        {
            // Você pode adicionar lógica de negócios adicional aqui, se necessário.

            // Chame o método de exclusão do repositório.
            await _curriculoRepository.DeleteCurriculoByIdAsync(id);
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