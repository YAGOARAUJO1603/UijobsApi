using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UijobsApi.Repositories.Idiomas;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.Idiomas
{
    public class IdiomaService : IIdiomaService
    {

        private readonly IIdiomaRepository _idiomaRepository;

        public IdiomaService(IIdiomaRepository idiomaRepository)
        {
            _idiomaRepository = idiomaRepository;
        }


        public async Task<Idioma> AddIdiomaAsync(Idioma novoIdioma)
        {
            var validationContext = new ValidationContext(novoIdioma, null, null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(novoIdioma, validationContext, validationResults, true))
            {
                // Se os dados não forem válidos, você pode lançar uma exceção ou tratar o erro de outra forma.
                throw new ValidationException("Os dados não são válidos.");
            }

            // Se os dados forem válidos, você pode continuar com a adição da escolaridade.
            return await _idiomaRepository.AddIdiomaAsync(novoIdioma);
        }

        public async Task DeleteIdiomaByIdAsync(int id)
        {
            // Você pode adicionar lógica de negócios adicional aqui, se necessário.

            // Chame o método de exclusão do repositório.
            await _idiomaRepository.DeleteIdiomaByIdAsync(id);
        }

        public async Task<IEnumerable<Idioma>> GetAllIdiomaAsync()
        {
            return await _idiomaRepository.GetAllIdiomaAsync();
        }

        public async Task<Idioma> GetIdiomaByIdAsync(int id)
        {
            Idioma idioma = await _idiomaRepository.GetIdiomaByIdAsync(id);

            if (idioma == null)
            {
                throw new NotFoundException("Candidato");
            }

            return idioma;
        }
    }
}