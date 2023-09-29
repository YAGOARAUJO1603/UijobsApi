using UIJobsAPI.Models;

namespace UijobsApi.Services.CurriculosConhecimentos
{
    public interface ICurriculoConhecimentoService
    {
        public Task<IEnumerable<CurriculoConhecimento>> GetAllCurriculoConhecimentosAsync();

        public Task<CurriculoConhecimento> GetCurriculoConhecimentoByIdAsync(int id);
        public Task<CurriculoConhecimento> AddCurriculoConhecimentoAsync(CurriculoConhecimento novoCurriculoConhecimento);

        public Task DeleteCurriculoConhecimentoByIdAsync(int id);
    }
}
