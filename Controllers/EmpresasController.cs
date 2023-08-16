using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UijobsApi.Data;
using UijobsApi.Models;

namespace UijobsApi.Controllers
{
    [ApiController]
    [Route("controller")]

    public class EmpresasController : ControllerBase
    {
        private readonly DataContext _context;

        public EmpresasController(DataContext context)
        {
            _context = context;
        }
        

        [HttpPost]
        public async Task<IActionResult> Add(Empresa novaEmpresa)
        {
            try
            {
                await _context.Empresas.AddAsync(novaEmpresa);
                await _context.SaveChangesAsync();

                return Ok(novaEmpresa.idEmpresa);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }










        
    }
}