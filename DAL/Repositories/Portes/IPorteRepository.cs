using UIJobsAPI.Models;

namespace UijobsApi.DAL.Repositories.Portes
{
    public interface IPorteRepository
    {
        //Listar todos
        public Task<IEnumerable<Porte>> GetAllPorteAsync();

        //listar por id
        public Task<Porte> GetPorteByIdAsync(int id);
    }
}
