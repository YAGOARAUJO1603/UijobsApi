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
            BeneficioVaga beneficioVagaExistente = await _beneficioVagaRepository.GetBeneficioVagaAsync(novoBeneficioVaga.idBeneficio, novoBeneficioVaga.idVagas);
            if (beneficioVagaExistente != null && beneficioVagaExistente.Equals(novoBeneficioVaga))
            {
                throw new Exception("Já existe um beneficio Vaga cadastrado com esse Id");
            }
            BeneficioVaga beneficioVaga = await _beneficioVagaRepository.AddBeneficioVagaAsync(novoBeneficioVaga);
            await _unitOfWork.SaveChangesAsync();
            return beneficioVaga;
        }

        public async Task DeleteBeneficioVagaByIdAsync(int idBeneficio, int idVaga)
        {
            var beneficioVagas = await _beneficioVagaRepository.GetBeneficioVagaAsync(idBeneficio,idVaga);

            if (beneficioVagas == null)
            {
                throw new NotFoundException("BeneficioVaga com id não existe");
            }

            await _beneficioVagaRepository.DeleteBeneficioVagaByIdAsync(idBeneficio, idVaga);
            await _unitOfWork.SaveChangesAsync();
        }

       /* public async Task<IEnumerable<BeneficioVaga>> GetBeneficioVagaByIdAsync(int id)
        {
            IEnumerable<BeneficioVaga> beneficioVaga = await _beneficioVagaRepository.GetBeneficioVagaByIdAsync(id);

            if (beneficioVaga == null)
            {
                throw new NotFoundException("BeneficioVaga");
            }

            return beneficioVaga;
        }*/

        public async Task<BeneficioVaga> GetBeneficioVagaAsync(int beneficioId, int vagaId)
        {
            var beneficioVaga = await _beneficioVagaRepository.GetBeneficioVagaAsync(beneficioId, vagaId);

            if (beneficioVaga == null)
            {
                throw new NotFoundException("BeneficioVaga não encontrado");
            }

            return beneficioVaga;
        }
    }
}
