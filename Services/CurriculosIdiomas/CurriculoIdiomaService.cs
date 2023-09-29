using UijobsApi.DAL.Repositories.CurriculosIdiomas;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Data;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.CurriculosIdiomas
{
    public class CurriculoIdiomaService : ICurriculoIdiomaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurriculoIdiomaRepository _curriculoIdiomaRepository;

        public CurriculoIdiomaService(IUnitOfWork unitOfWork, DataContext dataContext, ICurriculoIdiomaRepository curriculoIdioma)
        {
            _unitOfWork = unitOfWork;
            _curriculoIdiomaRepository = curriculoIdioma;
        }

        public async Task<CurriculoIdioma> AddCurriculoIdiomaAsync(CurriculoIdioma novoCurriculoIdioma)
        {
            CurriculoIdioma curriIdiomaExistente = await _curriculoIdiomaRepository.GetCurriculoIdiomasByIdAsync(novoCurriculoIdioma.idCurriculo);
            if (curriIdiomaExistente != null && curriIdiomaExistente.Equals(novoCurriculoIdioma))
            {
                // bad request exception \/
                throw new Exception("Já existe um cursoIdoma cadastrado com esse Id");
            }
            CurriculoIdioma curriculoIdoma= await _curriculoIdiomaRepository.AddCurriculoIdiomaAsync(novoCurriculoIdioma);
            await _unitOfWork.SaveChangesAsync();
            return curriculoIdoma;
        }

        public async Task DeleteCurriculoIdiomaByIdAsync(int id)
        {
            CurriculoIdioma curriculoIdioma = await _curriculoIdiomaRepository.GetCurriculoIdiomasByIdAsync(id);

            if (curriculoIdioma is null)
            {
                throw new NotFoundException("Curriculo Idioma com id não existe");
            }
            _curriculoIdiomaRepository.DeleteCurriculoIdiomaByIdAsync(curriculoIdioma);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<CurriculoIdioma>> GetAllCurriculoIdiomasAsync()
        {
            return await _curriculoIdiomaRepository.GetAllCurriculoIdiomasAsync();
        }

        public async Task<CurriculoIdioma> GetCurriculoIdiomasByIdAsync(int id)
        {
            CurriculoIdioma curriculoIdioma = await _curriculoIdiomaRepository.GetCurriculoIdiomasByIdAsync(id);

            if (curriculoIdioma == null)
            {
                throw new NotFoundException("Curriculo Idioma");
            }

            return curriculoIdioma;
        }
    }
}
