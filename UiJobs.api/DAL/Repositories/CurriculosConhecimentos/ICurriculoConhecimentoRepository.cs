using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.CurriculosConhecimentos
{
    public interface ICurriculoConhecimentoRepository
    {

        public Task<IEnumerable<CurriculoConhecimento>> GetAllCurriculoConhecimentosAsync();

        public Task<CurriculoConhecimento> GetCurriculoConhecimentoByIdAsync(int id);
        public Task<CurriculoConhecimento> AddCurriculoConhecimentoAsync(CurriculoConhecimento novoCurriculoConhecimento);

        public Task DeleteCurriculoConhecimentoByIdAsync(CurriculoConhecimento curriculoConhecimento);
    }
}
