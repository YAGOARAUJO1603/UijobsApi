using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Data;
using UIJobsAPI.Models;


namespace UijobsApi.DAL.Repositories.CarreirasProfissionais
{
    public class CarreiraProfissionalRepository : ICarreiraProfissionalRepository
    {

        private readonly DataContext _context;

        public CarreiraProfissionalRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<CarreiraProfissional> AddCarreiraProfissionalAsync(CarreiraProfissional NovaCarreiraProfissional)
        {
            await _context.CarreiraProfissional.AddAsync(NovaCarreiraProfissional);
            return NovaCarreiraProfissional;

        }

        public async Task DeleteCarreiraProfissionalAsync(CarreiraProfissional id)
        {
            _context.CarreiraProfissional.Remove(id);
        }

        public async Task<CarreiraProfissional> GetCarreiraProfissionalByIdAsync(int id)
        {
            return await _context.CarreiraProfissional.FirstOrDefaultAsync(carrProf => carrProf.idCarreiraProfissional == id);
        }





    }
}