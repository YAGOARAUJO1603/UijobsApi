using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UijobsApi.Models;

namespace UijobsApi.Controllers
{
    public class CandidatosExemploController : ControllerBase
    {
        //Toda codificação ficara aqui
    private static List<Candidato> candidatos = new List<Candidato>()
    {
        new Candidato() {Id = 1, Nome = "Yago", NomeMae = "Elaine", Email = "yago.pereira7@etec.sp.gov.br", CEP = "02124050"},
        new Candidato() {Id = 2, Nome = "Daniel", NomeMae = "Maria", Email = "Daniel@etec.sp.gov.br", CEP = "02124040"},
        new Candidato() {Id = 3, Nome = "Lara", NomeMae = "Maria Beatriz", Email = "Lara@etec.sp.gov.br", CEP = "02179010"}
    };



    [HttpGet("Get")]
    public IActionResult Get()
    {
        return Ok(candidatos);
    }       

    [HttpGet("{Id}")]
    public IActionResult GetSingle(int id)
    {
        return Ok(candidatos.FirstOrDefault(ca => ca.Id == id));
    }

    //Adicionando novo Candidato
    [HttpPost]
    public IActionResult AddCandidato(Candidato novoCandidatoExemplo)
    {
        if (novoCandidatoExemplo.NomeMae == null)
        return BadRequest("Obrigatório informar o nome da genetriz");

        candidatos.Add(novoCandidatoExemplo);
        return Ok(candidatos);
    }

   // Busca por nome aproximado
    [HttpGet("GetByNomeAproximado/{nome}")]
    public IActionResult GetByNomeAproximado(string nome)
    {
        List<Candidato> listabusca = candidatos.FindAll(c => c.Nome.Contains(nome));
        return Ok(listabusca);
    }
 
    //Atualizar dados do candidato
    [HttpPut]
    public IActionResult UpdateCandidato(Candidato c)
    {
        Candidato candAlterado = candidatos.Find(cand => cand.Id == c.Id);
        candAlterado.Nome = c.Nome;
        candAlterado.NomeMae = c.NomeMae;
        candAlterado.Email = c.Email;
        candAlterado.CEP = c.CEP;

        return Ok(candidatos);
    }

    //Deletar candidato
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        candidatos.RemoveAll(cand => cand.Id == id);

        return Ok(candidatos);

    }

    



















    }
}