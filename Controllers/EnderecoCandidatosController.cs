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
    
    public class EnderecoCandidatosController : ControllerBase
    {
        
        private readonly DataContext _context;

        public EnderecoCandidatosController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add(EnderecoCandidato CadastrarEndereco)
        {
            try
            {
                await _context.EnderecoCandidatos.AddAsync(CadastrarEndereco);
                await _context.SaveChangesAsync();

                return Ok(CadastrarEndereco.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                EnderecoCandidato endRemover = await _context.EnderecoCandidatos.FirstOrDefaultAsync(end => end.Id == id);

                _context.EnderecoCandidatos.Remove(endRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
















    }
}