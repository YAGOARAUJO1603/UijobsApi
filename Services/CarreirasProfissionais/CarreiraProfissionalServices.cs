using UIJobsAPI.Models;
using UIJobsAPI.Exceptions;
using UijobsApi.DAL.Repositories.CarreirasProfissionais;
using UijobsApi.DAL.Unit_of_Work;

namespace UijobsApi.Services.CarreirasProfissionais
{
    public class CarreiraProfissionalServices : ICarreiraProfissionalServices
    {

        private readonly ICarreiraProfissionalRepository _carreiraProfissionalRepository;
        private readonly IUnitOfWork _unitOfWork;
        private object _context;

        public CarreiraProfissionalServices(ICarreiraProfissionalRepository carreiraProfissionalRepository, IUnitOfWork unitOfWork)
        {
            _carreiraProfissionalRepository = carreiraProfissionalRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<CarreiraProfissional> AddCarreiraProfissionalAsync(CarreiraProfissional novaCarreiraProfissional)
        {
            CarreiraProfissional carreiraProfissionalExistente = await _carreiraProfissionalRepository.GetCarreiraProfissionalByIdAsync(novaCarreiraProfissional.sqCarreiraProfissional);
            if (carreiraProfissionalExistente != null && carreiraProfissionalExistente.Equals(novaCarreiraProfissional))
            {
                // bad request exception \/
                throw new Exception("Já existe carreira Profissional Cadastrada.");
            }
            CarreiraProfissional carreiraProfissional = await _carreiraProfissionalRepository.AddCarreiraProfissionalAsync(novaCarreiraProfissional);
            await _unitOfWork.SaveChangesAsync();
            return carreiraProfissional;
        }

  

        public async Task<CarreiraProfissional> GetCarreiraProfissionalByIdAsync(int id)
        {
            CarreiraProfissional carreiraProfissional = await _carreiraProfissionalRepository.GetCarreiraProfissionalByIdAsync(id);

            if (carreiraProfissional == null)
            {
                throw new NotFoundException("Carreira Profissional");
            }

            return carreiraProfissional;
        }



          public async Task DeleteCarreiraProfissionalAsync(int id)
        {
            CarreiraProfissional carreiraProfissional = await _carreiraProfissionalRepository.GetCarreiraProfissionalByIdAsync(id);

            if (carreiraProfissional is null)
            {
                throw new NotFoundException("Candidato com id não existe");
            }
            _carreiraProfissionalRepository.DeleteCarreiraProfissionalAsync(carreiraProfissional);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task<IEnumerable<CarreiraProfissional>> GetCarreiraProfissionalByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}