using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.CurriculosIdiomas
{
    public interface ICurriculoIdiomaRepository
    {
        public Task<IEnumerable<CurriculoIdioma>> GetAllCurriculoIdiomasAsync();

        public Task<CurriculoIdioma> GetCurriculoIdiomasByIdAsync(int id);
        public Task<CurriculoIdioma> AddCurriculoIdiomaAsync(CurriculoIdioma novoCurriculoIdioma);

        public Task DeleteCurriculoIdiomaByIdAsync(CurriculoIdioma curriculoIdioma);
    }
}
