using UIJobsAPI.Models;

namespace UijobsApi.Services.SituacoesVagas
{
    public interface ISituacaoVagaService
    {
        //Listar todos
        public Task<IEnumerable<SituacaoVaga>> GetAllSituacaoVagaAsync();

        //listar por id
        public Task<SituacaoVaga> GetSituacaoVagaByIdAsync(int id);
    }
}
