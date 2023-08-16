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

    public class CurriculosController : ControllerBase
    {
        // Toda codificação ficará aqui
        private readonly DataContext _context;

        public CurriculosController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Curriculo CadastrarCurriculo)
        {
            try
            {
                await _context.Curriculos.AddAsync(CadastrarCurriculo);
                await _context.SaveChangesAsync();

                return Ok(CadastrarCurriculo.CurriculoId);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut()]
        public async Task<IActionResult> Update(Curriculo AlterarCurriculo)
        {
            try
            {
                
                    _context.Curriculos.Update(AlterarCurriculo);
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
                Curriculo currRemover = await _context.Curriculos.FirstOrDefaultAsync(curr => curr.CurriculoId == id);

                _context.Curriculos.Remove(currRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }   

        //FAZER PARAMETRO PercAderencia



























        
    } // fim da classe de tipo CONTROLLER
}