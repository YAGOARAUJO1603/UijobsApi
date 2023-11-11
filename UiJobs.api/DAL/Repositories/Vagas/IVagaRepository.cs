using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.Vagas
{
    public interface IVagaRepository
    {
        //Listar todos
        public Task<IEnumerable<Vaga>> GetAllVagaAsync();

        //listar por id
        public Task<Vaga> GetVagaByIdAsync(int id);

        public Task<Vaga> AddVagaAsync(Vaga novaVaga);

        public Task DeleteVagaByIdAsync(Vaga vaga);
    }
}
