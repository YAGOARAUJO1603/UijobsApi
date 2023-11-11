using UijobsApi.DAL.Repositories;
using UijobsApi.DAL.Repositories.Idiomas;
using UijobsApi.DAL.Repositories.Vagas;
using UijobsApi.DAL.Unit_of_Work;
using UijobsApi.Exceptions;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.Vagas
{
    public class VagaService : IVagaService
    {
        private readonly IVagaRepository _vagaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VagaService(IVagaRepository vagaRepository, IUnitOfWork unitOfWork)
        {
            _vagaRepository = vagaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Vaga> GetVagaByIdAsync(int id)
        {
            Vaga vaga = await _vagaRepository.GetVagaByIdAsync(id);

            if (vaga == null)
            {
                throw new NotFoundException("vaga");
            }

            return vaga;
        }
        public async Task<IEnumerable<Vaga>> GetAllVagaAsync()
        {
            return await _vagaRepository.GetAllVagaAsync();
        }

        public async Task<Vaga> AddVagaAsync(Vaga novaVaga)
        {
            ValidarCargaHoraria(novaVaga.cargaHoraria);
            Vaga vaga = await _vagaRepository.AddVagaAsync(novaVaga);
            await _unitOfWork.SaveChangesAsync();
            return vaga;
        }

        public async Task DeleteVagaByIdAsync(int id)
        {
            Vaga vaga = await _vagaRepository.GetVagaByIdAsync(id);

            if (vaga is null)
            {
                throw new NotFoundException("Vaga com id não existe");
            }
            _vagaRepository.DeleteVagaByIdAsync(vaga);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task ValidarCargaHoraria(ushort cargaHoraria)
        {
            if (cargaHoraria > 40 || cargaHoraria < 30)
            {
                throw new BadRequestException("Carga horária não permitida pela Lei. A carga horária máxima é de 40 horas semanais.");
            }
            return null;
        }
    }
}
