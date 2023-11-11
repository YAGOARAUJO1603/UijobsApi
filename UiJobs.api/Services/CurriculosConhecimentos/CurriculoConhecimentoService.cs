using UijobsApi.DAL.Repositories.CurriculosConhecimentos;
using UijobsApi.DAL.Repositories.Cursos;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.CurriculosConhecimentos
{
    public class CurriculoConhecimentoService : ICurriculoConhecimentoService
    {
        private readonly ICurriculoConhecimentoRepository _curriculoConhecimentoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CurriculoConhecimentoService(ICurriculoConhecimentoRepository curriculoConhecimentoRepository, IUnitOfWork unitOfWork)
        {
            _curriculoConhecimentoRepository = curriculoConhecimentoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CurriculoConhecimento> AddCurriculoConhecimentoAsync(CurriculoConhecimento novoCurriculoConhecimento)
        {
            CurriculoConhecimento curriConheExistente = await _curriculoConhecimentoRepository.GetCurriculoConhecimentoByIdAsync(novoCurriculoConhecimento.idCurriculo);
            if (curriConheExistente != null && curriConheExistente.Equals(novoCurriculoConhecimento))
            {
                // bad request exception \/
                throw new Exception("Já existe um curso cadastrado com esse Id");
            }
            CurriculoConhecimento curriculoConhecimento = await _curriculoConhecimentoRepository.AddCurriculoConhecimentoAsync(novoCurriculoConhecimento);
            await _unitOfWork.SaveChangesAsync();
            return curriculoConhecimento;
        }

        public async Task DeleteCurriculoConhecimentoByIdAsync(int id)
        {
            CurriculoConhecimento curriculoConhecimento = await _curriculoConhecimentoRepository.GetCurriculoConhecimentoByIdAsync(id);

            if (curriculoConhecimento is null)
            {
                throw new NotFoundException("Curriculo Conhecimento com id não existe");
            }
            _curriculoConhecimentoRepository.DeleteCurriculoConhecimentoByIdAsync(curriculoConhecimento);
            await _unitOfWork.SaveChangesAsync();
        }



        public async Task<IEnumerable<CurriculoConhecimento>> GetAllCurriculoConhecimentosAsync()
        {
            return await _curriculoConhecimentoRepository.GetAllCurriculoConhecimentosAsync();
        }

        public async Task<CurriculoConhecimento> GetCurriculoConhecimentoByIdAsync(int id)
        {
            CurriculoConhecimento curriculoConhecimento = await _curriculoConhecimentoRepository.GetCurriculoConhecimentoByIdAsync(id);

            if (curriculoConhecimento == null)
            {
                throw new NotFoundException("Curriculo Conhecimento");
            }

            return curriculoConhecimento;
        }
    }
}
