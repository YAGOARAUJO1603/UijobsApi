using UIJobsAPI.Models;

namespace UijobsApi.Services.CurriculosIdiomas
{
    public interface ICurriculoIdiomaService
    {
        public Task<IEnumerable<CurriculoIdioma>> GetAllCurriculoIdiomasAsync();

        public Task<CurriculoIdioma> GetCurriculoIdiomasByIdAsync(int id);
        public Task<CurriculoIdioma> AddCurriculoIdiomaAsync(CurriculoIdioma novoCurriculoIdioma);

        public Task DeleteCurriculoIdiomaByIdAsync(int id);
    }
}
