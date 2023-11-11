using UijobsApi.DAL.Repositories.Vagas;
using UijobsApi.DAL.Repositories.VagasConhecimentos;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.VagasConhecimentos
{
    public class VagaConhecimentoService : IVagaConhecimentoService
    {
        private readonly IVagaConhecimentoRepository _vagaConhecimentoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VagaConhecimentoService(IVagaConhecimentoRepository vagaConhecimentoRepository, IUnitOfWork unitOfWork)
        {
            _vagaConhecimentoRepository = vagaConhecimentoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VagaConhecimento> GetVagaConhecimentoByIdAsync(int id)
        {
            VagaConhecimento vagaConhecimento = await _vagaConhecimentoRepository.GetVagaConhecimentoByIdAsync(id);

            if (vagaConhecimento == null)
            {
                throw new NotFoundException("vaga conhecimento");
            }

            return vagaConhecimento;
        }

        public async Task<IEnumerable<VagaConhecimento>> GetAllVagaConhecimentoAsync()
        {
            return await _vagaConhecimentoRepository.GetAllVagaConhecimentoAsync();
        }

        public async Task<VagaConhecimento> AddVagaConhecimentoAsync(VagaConhecimento novaVagaConhecimento)
        {
            VagaConhecimento vagaConheExistente = await _vagaConhecimentoRepository.GetVagaConhecimentoByIdAsync(novaVagaConhecimento.idConhecimentos);
            if (vagaConheExistente != null && vagaConheExistente.Equals(novaVagaConhecimento))
            {
                // bad request exception \/
                throw new Exception("Já existe uma Vaga cadastrado com esse Id.");
            }
            VagaConhecimento vagaConhecimento = await _vagaConhecimentoRepository.AddVagaConhecimentoAsync(novaVagaConhecimento);
            await _unitOfWork.SaveChangesAsync();
            return vagaConhecimento;
        }

        public async Task DeleteVagaConhecimentoByIdAsync(int id)
        {
            VagaConhecimento vagaConhecimento = await _vagaConhecimentoRepository.GetVagaConhecimentoByIdAsync(id);

            if (vagaConhecimento is null)
            {
                throw new NotFoundException("Vaga Conhecimento com id não existe");
            }
            _vagaConhecimentoRepository.DeleteVagaConhecimentoByIdAsync(vagaConhecimento);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
