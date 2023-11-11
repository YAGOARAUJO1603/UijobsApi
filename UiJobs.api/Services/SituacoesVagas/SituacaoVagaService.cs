using UijobsApi.DAL.Repositories.SituacoesVagas;
using UijobsApi.DAL.Repositories.Vagas;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.SituacoesVagas
{
    public class SituacaoVagaService : ISituacaoVagaService
    {
        private readonly ISituacaoVagaRepository _situacaoVagaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SituacaoVagaService(ISituacaoVagaRepository situacaoVagaRepository, IUnitOfWork unitOfWork)
        {
            _situacaoVagaRepository = situacaoVagaRepository;
            _unitOfWork = unitOfWork;
        }

        public async  Task<IEnumerable<SituacaoVaga>> GetAllSituacaoVagaAsync()
        {
            return await _situacaoVagaRepository.GetAllSituacaoVagaAsync();
        }

        public async Task<SituacaoVaga> GetSituacaoVagaByIdAsync(int id)
        {
            SituacaoVaga situacaoVaga = await _situacaoVagaRepository.GetSituacaoVagaByIdAsync(id);

            if (situacaoVaga == null)
            {
                throw new NotFoundException("Situacao Vaga");
            }

            return situacaoVaga;
        }
    }
}
