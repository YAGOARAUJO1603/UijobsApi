using UijobsApi.DAL.Repositories.BeneficiosVagas;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.BeneficiosVagas
{
    public class BeneficioVagaService : IBeneficioVagaService
    {
        private readonly IBeneficioVagaRepository _beneficioVagaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BeneficioVagaService(IBeneficioVagaRepository beneficioVagaRepository, IUnitOfWork unitOfWork)
        {
            _beneficioVagaRepository = beneficioVagaRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<BeneficioVaga> AddBeneficioVagaAsync(BeneficioVaga novoBeneficioVaga)
        {
            BeneficioVaga beneficioVagaExistente = await _beneficioVagaRepository.GetBeneficioVagaByIdAsync(novoBeneficioVaga.idBeneficio);
            if (beneficioVagaExistente != null && beneficioVagaExistente.Equals(novoBeneficioVaga))
            {
                // bad request exception \/
                throw new Exception("Já existe um beneficio Vaga cadastrado com esse Id");
            }
            BeneficioVaga beneficioVaga = await _beneficioVagaRepository.AddBeneficioVagaAsync(novoBeneficioVaga);
            await _unitOfWork.SaveChangesAsync();
            return beneficioVaga;
        }

        public async Task DeleteBeneficioVagaByIdAsync(int id)
        {
            BeneficioVaga beneficioVaga = await _beneficioVagaRepository.GetBeneficioVagaByIdAsync(id);

            if (beneficioVaga is null)
            {
                throw new NotFoundException("BeneficioVaga com id não existe");
            }
            _beneficioVagaRepository.DeleteBeneficioVagaByIdAsync(beneficioVaga);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<BeneficioVaga> GetBeneficioVagaByIdAsync(int id)
        {
            BeneficioVaga beneficioVaga = await _beneficioVagaRepository.GetBeneficioVagaByIdAsync(id);

            if (beneficioVaga == null)
            {
                throw new NotFoundException("BeneficioVaga");
            }

            return beneficioVaga;
        }
    }
}
