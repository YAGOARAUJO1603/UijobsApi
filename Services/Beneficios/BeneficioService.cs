using UijobsApi.DAL.Repositories.Beneficios;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.Beneficios
{
    public class BeneficioService : IBeneficioService
    {
        private readonly IBeneficioRepository _beneficioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BeneficioService(IBeneficioRepository beneficioRepository, IUnitOfWork unitOfWork)
        {
            _beneficioRepository = beneficioRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Beneficio> AddBeneficioAsync(Beneficio novoBeneficio)
        {
            Beneficio beneficioExistente = await _beneficioRepository.GetBeneficioByIdAsync(novoBeneficio.idBeneficio);
            if (beneficioExistente != null && beneficioExistente.Equals(novoBeneficio))
            {
                // bad request exception \/
                throw new Exception("Já existe um beneficio cadastrado com esse Id");
            }
            Beneficio beneficio = await _beneficioRepository.AddBeneficioAsync(novoBeneficio);
            await _unitOfWork.SaveChangesAsync();
            return beneficio;
        }

        public async Task DeleteBeneficioByIdAsync(int id)
        {
            Beneficio beneficio = await _beneficioRepository.GetBeneficioByIdAsync(id);

            if (beneficio is null)
            {
                throw new NotFoundException("Beneficio com id não existe");
            }
            _beneficioRepository.DeleteBeneficioByIdAsync(beneficio);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Beneficio>> GetAllBeneficioAsync()
        {
            return await _beneficioRepository.GetAllBeneficioAsync();
        }

        public async Task<Beneficio> GetBeneficioByIdAsync(int id)
        {
            Beneficio beneficio = await _beneficioRepository.GetBeneficioByIdAsync(id);

            if (beneficio == null)
            {
                throw new NotFoundException("Beneficio");
            }

            return beneficio;
        }
    }
}
