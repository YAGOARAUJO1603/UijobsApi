using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIJobsAPI.Models;

namespace UijobsApi.Services.FormacoesAcademicas
{
    public interface IFormacaoAcademicaService
    {
        public Task<IEnumerable<FormacaoAcademica>> GetAllFormacoesAcademicasAsync();

        public Task<FormacaoAcademica> GetFormacoesAcademicasByIdAsync(int id);
        public Task<FormacaoAcademica> AddFormacoesAcademicasAsync(FormacaoAcademica novaFormacaoAcademica);

        public Task DeleteFormacoesAcademicasByIdAsync(int id);

    }
}