using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.FormacoesAcademicas
{
    public interface IFormacaoAcademicaRepository
    {
        public Task<IEnumerable<FormacaoAcademica>> GetAllFormacoesAcademicasAsync();

        public Task<FormacaoAcademica> GetFormacoesAcademicasByIdAsync(int id);
        public Task<FormacaoAcademica> AddFormacoesAcademicasAsync(FormacaoAcademica novaFormacaoAcademica);

        public Task DeleteFormacoesAcademicasByIdAsync(FormacaoAcademica formacaoAcademica);
    }
}