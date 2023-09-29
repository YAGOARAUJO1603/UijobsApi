using UIJobsAPI.Models;

namespace UijobsApi.Services.Vagas
{
    public interface IVagaService
    {
        //Listar todos
        public Task<IEnumerable<Vaga>> GetAllVagaAsync();

        //listar por id
        public Task<Vaga> GetVagaByIdAsync(int id);

        public Task<Vaga> AddVagaAsync(Vaga novaVaga);

        public Task DeleteVagaByIdAsync(int id);
    }
}
