using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.Idiomas
{
    public interface IIdiomaRepository
    {
        public Task<IEnumerable<Idioma>> GetAllIdiomaAsync();
        //Listar todos

        public Task<Idioma> GetIdiomaByIdAsync(int id);
        //listar por id

        public Task<Idioma> AddIdiomaAsync(Idioma novoIdioma);

<<<<<<< HEAD
        public Task DeleteIdiomaByIdAsync(Idioma idioma);
=======
        public Task DeleteIdiomaByIdAsync(Idioma idioma;
>>>>>>> 082cb01ceb7037aaaa31e092c2bf6803ee31e40f

    }
}