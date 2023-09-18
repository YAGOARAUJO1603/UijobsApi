using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UijobsApi.DAL.Repositories.FormacoesAcademicas;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.FormacoesAcademicas
{
    public class FormacaoAcademicaService : IFormacaoAcademicaService
    {

        private readonly IFormacaoAcademicaRepository _formacaoAcademicaRepository;

        public FormacaoAcademicaService(IFormacaoAcademicaRepository formacaoAcademicaRepository)
        {
            _formacaoAcademicaRepository = formacaoAcademicaRepository;
        }


        public async Task<FormacaoAcademica> AddFormacoesAcademicasAsync(FormacaoAcademica novaFormacaoAcademica)
        {
            var validationContext = new ValidationContext(novaFormacaoAcademica, null, null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(novaFormacaoAcademica, validationContext, validationResults, true))
            {
                // Se os dados não forem válidos, você pode lançar uma exceção ou tratar o erro de outra forma.
                throw new ValidationException("Os dados não são válidos.");
            }

            // Se os dados forem válidos, você pode continuar com a adição da escolaridade.
            return await _formacaoAcademicaRepository.AddFormacoesAcademicasAsync(novaFormacaoAcademica);
        }

        public async Task DeleteFormacoesAcademicasByIdAsync(FormacaoAcademica id)
        {
            // Você pode adicionar lógica de negócios adicional aqui, se necessário.

            // Chame o método de exclusão do repositório.
            await _formacaoAcademicaRepository.DeleteFormacoesAcademicasByIdAsync(id);
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