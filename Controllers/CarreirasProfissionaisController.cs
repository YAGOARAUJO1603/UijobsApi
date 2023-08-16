using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UijobsApi.Data;
using UijobsApi.Models;

namespace UijobsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class CarreirasProfissionaisController : ControllerBase
    {
        private readonly DataContext _context;

        public CarreirasProfissionaisController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarreiraProfissional CadastrarCarreiraProfissional)
        {
            try
            {
                await _context.CarreirasProfissionais.AddAsync(CadastrarCarreiraProfissional);
                await _context.SaveChangesAsync();

                return Ok(CadastrarCarreiraProfissional.idCarreiraProfissional);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Update(CarreiraProfissional AlterarCarreiraProfissional)
        {
            try
            {
                /*var cliente = await _context.Clientes.FirstOrDefaultAsync(p => p.Id == clienteAtualizado.Id);

                if (cliente == null)
                {
                    throw new Exception("Cliente não pode ser nulo");
                }*/
                    _context.CarreirasProfissionais.Update(AlterarCarreiraProfissional);
                    int linhaAfetadas = await _context.SaveChangesAsync();


                return Ok(linhaAfetadas);
            }   
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                CarreiraProfissional carrRemover = await _context.CarreirasProfissionais.FirstOrDefaultAsync(carr => carr.idCarreiraProfissional == id);

                _context.CarreirasProfissionais.Remove(carrRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Listar
         [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<CarreiraProfissional> lista = await _context.CarreirasProfissionais.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Consultar")]
    public async Task<IActionResult> Consultar(string Cargo)
    {
        try
        {
            // Consulta a carreira com base no cargo
            List<CarreiraProfissional> lista = await _context.CarreirasProfissionais.Where(carr => carr.cargo.Contains(Cargo)).ToListAsync();
            return Ok(lista);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

        






























    }
}