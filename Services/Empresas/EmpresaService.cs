using UijobsApi.DAL.Repositories.Empresas;
using UijobsApi.DAL.Unit_of_Work;
using UIJobsAPI.Exceptions;
using UIJobsAPI.Models;

namespace UijobsApi.Services.Empresas
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private object _context;

        public EmpresaService(IEmpresaRepository empresaRepository, IUnitOfWork unitOfWork)
        {
            _empresaRepository = empresaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Empresa> AddEmpresaAsync(Empresa novaEmpresa)
        {
            Empresa empresaExistente = await _empresaRepository.GetEmpresaByIdAsync(novaEmpresa.idEmpresa);
            if (empresaExistente != null && empresaExistente.Equals(novaEmpresa))
            {
                // bad request exception \/
                throw new Exception("Já existe uma empresa Cadastrada com esse perfil.");
            }
            Empresa empresa = await _empresaRepository.AddEmpresaAsync(novaEmpresa);
            await _unitOfWork.SaveChangesAsync();
            return empresa;
        }

        public async Task DeleteEmpresaAsync(int id)
        {
            Empresa empresa = await _empresaRepository.GetEmpresaByIdAsync(id);

            if (empresa is null)
            {
                throw new NotFoundException("Candidato com id não existe");
            }
            _empresaRepository.DeleteEmpresaAsync(empresa);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<Empresa> GetEmpresaByIdAsync(int id)
        {
            Empresa empresa = await _empresaRepository.GetEmpresaByIdAsync(id);

            if (empresa == null)
            {
                throw new NotFoundException("Empresa");
            }

            return empresa;
        }
    }
}
