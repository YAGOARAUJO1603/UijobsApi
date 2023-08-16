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
    public class EnderecoEmpresasController : ControllerBase 
    {
                private readonly DataContext _context;

        public EnderecoEmpresasController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add(EnderecoEmpresa CadastrarEndereco)
        {
            try
            {
                await _context.EnderecoEmpresas.AddAsync(CadastrarEndereco);
                await _context.SaveChangesAsync();

                return Ok(CadastrarEndereco.idEndereco);
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
                EnderecoEmpresa endeRemover = await _context.EnderecoEmpresas.FirstOrDefaultAsync(ende => ende.idEndereco == id);

                _context.EnderecoEmpresas.Remove(endeRemover);
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