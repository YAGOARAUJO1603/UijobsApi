using UijobsApi.DAL.Repositories.Portes;
using UijobsApi.DAL.Repositories.SituacoesVagas;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.Portes
{
    public class PorteService : IPorteService
    {
        private readonly IPorteRepository _porteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PorteService(IPorteRepository porteRepository, IUnitOfWork unitOfWork)
        {
            _porteRepository = porteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Porte>> GetAllPorteAsync()
        {
            return await _porteRepository.GetAllPorteAsync();
        }

        public async  Task<Porte> GetPorteByIdAsync(int id)
        {
            Porte porte = await _porteRepository.GetPorteByIdAsync(id);

            if (porte == null)
            {
                throw new NotFoundException("Porte");
            }

            return porte;
        }
    }
}
