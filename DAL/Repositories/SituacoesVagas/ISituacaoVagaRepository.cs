using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.SituacoesVagas
{
    public interface ISituacaoVagaRepository
    {
        //Listar todos
        public Task<IEnumerable<SituacaoVaga>> GetAllSituacaoVagaAsync();

        //listar por id
        public Task<SituacaoVaga> GetSituacaoVagaByIdAsync(int id);
    }
}
