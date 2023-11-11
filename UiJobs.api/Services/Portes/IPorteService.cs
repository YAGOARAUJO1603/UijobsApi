using UIJobsAPI.Models;

namespace UijobsApi.Services.Portes
{
    public interface IPorteService
    {
        //Listar todos
        public Task<IEnumerable<Porte>> GetAllPorteAsync();

        //listar por id
        public Task<Porte> GetPorteByIdAsync(int id);
    }
}
