using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UijobsApi.DAL.Repositories.Idiomas;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.Idiomas
{
    public class IdiomaService : IIdiomaService
    {

        private readonly IIdiomaRepository _idiomaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public IdiomaService(IIdiomaRepository idiomaRepository, IUnitOfWork unitOfWork)
        {
            _idiomaRepository = idiomaRepository;
            _unitOfWork = unitOfWork;
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
        public async Task<IEnumerable<Idioma>> GetAllIdiomaAsync()
        {
            return await _idiomaRepository.GetAllIdiomaAsync();
        }

        public async Task<Idioma> AddIdiomaAsync(Idioma novoIdioma)
        {
            Idioma idiomaExistente = await _idiomaRepository.GetIdiomaByIdAsync(novoIdioma.idIdiomas);
            if (idiomaExistente != null && idiomaExistente.Equals(novoIdioma))
            {
                // bad request exception \/
                throw new Exception("Já existe um idioma cadastrado com esse Id.");
            }
            Idioma idioma = await _idiomaRepository.AddIdiomaAsync(novoIdioma);
            await _unitOfWork.SaveChangesAsync();
            return idioma;
        }

        public async Task DeleteIdiomaByIdAsync(int id)
        {
            Idioma idioma = await _idiomaRepository.GetIdiomaByIdAsync(id);

            if (idioma is null)
            {
                throw new NotFoundException("Idioma com id não existe");
            }
            _idiomaRepository.DeleteIdiomaByIdAsync(idioma);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}