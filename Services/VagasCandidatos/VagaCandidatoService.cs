using UijobsApi.DAL.Repositories.VagasCandidatos;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.VagasCandidatos
{
    public class VagaCandidatoService : IVagaCandidatoService
    {
        private readonly IVagaCandidatoRepository _vagaCandidatoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VagaCandidatoService(IUnitOfWork unitOfWork, IVagaCandidatoRepository vagaCandidatoRepository)
        {
            _unitOfWork = unitOfWork;
            _vagaCandidatoRepository = vagaCandidatoRepository;
        }

        public async Task<VagaCandidato> AddVagaCandidatoAsync(VagaCandidato novaVagaCandidato)
        {
            VagaCandidato vagaCandiExistente = await _vagaCandidatoRepository.GetVagaCandidatoByIdAsync(novaVagaCandidato.idCurriculo);
            if (vagaCandiExistente != null && vagaCandiExistente.Equals(novaVagaCandidato))
            {
                // bad request exception \/
                throw new Exception("Já existe um curso cadastrado com esse Id");
            }
           VagaCandidato vagaCandidato = await _vagaCandidatoRepository.AddVagaCandidatoAsync(novaVagaCandidato);
            await _unitOfWork.SaveChangesAsync();
            return vagaCandidato;
        }

        public async Task DeleteVagaCandidatoByIdAsync(int id)
        {
            VagaCandidato vagaCandidato = await _vagaCandidatoRepository.GetVagaCandidatoByIdAsync(id);

            if (vagaCandidato is null)
            {
                throw new NotFoundException("VagaCandidato com id não existe");
            }
            _vagaCandidatoRepository.DeleteVagaCandidatoByIdAsync(vagaCandidato);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<VagaCandidato>> GetAllVagaCandidatoAsync()
        {
            return await _vagaCandidatoRepository.GetAllVagaCandidatoAsync();
        }

        public async Task<VagaCandidato> GetVagaCandidatoByIdAsync(int id)
        {
            VagaCandidato vagaCandidato = await _vagaCandidatoRepository.GetVagaCandidatoByIdAsync(id);

            if (vagaCandidato == null)
            {
                throw new NotFoundException("Vaga Candidato");
            }

            return vagaCandidato;
        }
    }
}
