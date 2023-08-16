using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UijobsApi.Models;

namespace UijobsApi.Data
{
    public class DataContext : DbContext
    {
        //Toda codificação ficara aqui 

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Candidato> Candidatos {get; set;}
        public DbSet<Curriculo> Curriculos {get; set;}
        public DbSet<EnderecoCandidato> EnderecoCandidatos {get; set;}
        public DbSet<CarreiraProfissional> CarreirasProfissionais {get; set;}
        public DbSet<FormacaoAcademica> FormacoesAcademicas {get; set;}
        public DbSet<Conhecimento> Conhecimentos {get; set;}
        public DbSet<Curso> Cursos {get; set;}
        public DbSet<Graduacao> Graduacoes {get;set;}
        public DbSet<CursoVaga> CursosVagas {get; set;}
        public DbSet<ConhecimentoVaga> ConhecimentosVagas {get;set;}
        public DbSet<Nivel> Niveis {get; set;}
        public DbSet<Empresa> Empresas {get; set;}
        public DbSet<Porte> Portes {get; set;}
        public DbSet<EnderecoEmpresa> EnderecoEmpresas {get; set;}
        public DbSet <Vaga> Vagas {get; set;}
        public DbSet<SituacaoVaga> SituacoesVagas {get; set;}
        public DbSet<BeneficioVaga> BeneficiosVagas {get; set;}
        public DbSet<Beneficio> Beneficios {get; set;}
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidato>().HasData
            (
                new Candidato() {Id = 1, Nome = "Yago", NomeMae = "Elaine", Email = "yago.pereira7@etec.sp.gov.br", CEP = "02124050"},
                new Candidato() {Id = 2, Nome = "Daniel", NomeMae = "Maria", Email = "Daniel@etec.sp.gov.br", CEP = "02124040"},
                new Candidato() {Id = 3, Nome = "Lara", NomeMae = "Maria Beatriz", Email = "Lara@etec.sp.gov.br", CEP = "02179010"}
            );

            modelBuilder.Entity<Curriculo>().HasData
            (
                new Curriculo() {CurriculoId = 1, Objetivo = "1emprego", ConhecimentoId = "Iniciante", idFormacaoAcademica = "TÉCNICO EM ANALISE E DESENVOLVIMENTO DE SISTEMAS", idCarreiraProficional = "nula" },
                new Curriculo() {CurriculoId = 2,Objetivo = "OportunidadeArea", ConhecimentoId = "Intermediario", idFormacaoAcademica = "TÉCNICO EM ANALISE E DESENVOLVIMENTO DE SISTEMAS", idCarreiraProficional = "Vendas" },
                new Curriculo() {CurriculoId = 3,Objetivo = "MelhorEmprego", ConhecimentoId = "Avancado", idFormacaoAcademica = "TÉCNICO EM ANALISE E DESENVOLVIMENTO DE SISTEMAS", idCarreiraProficional = "Programador" }
            );

            modelBuilder.Entity<EnderecoCandidato>().HasData
            (
                new EnderecoCandidato() {Id = 1, CEP = "02124050", endereco ="Rua Togo", numero = 426, complemento =  "1", bairro = "Jardim Japão", cidade = "Sao Paulo", uf = "sp"},
                new EnderecoCandidato() {Id = 2, CEP = "02124040", endereco ="Rua Osaka", numero = 751, complemento =  "3", bairro = "Jardim Japão", cidade = "Sao Paulo", uf = "sp"},
                new EnderecoCandidato() {Id = 3, CEP = "02179010", endereco ="Rua Sargento", numero = 420, complemento =  "34B", bairro = "Parque Novo Mundo", cidade = "Sao Paulo", uf = "sp"}
            );

            modelBuilder.Entity<CarreiraProfissional>().HasData
            (
                new CarreiraProfissional() {idCarreiraProfissional = 1, nomeEmpresa = "NULO", tempo = "NULO", cargo = "NULO"},
                new CarreiraProfissional() {idCarreiraProfissional = 2, nomeEmpresa = "Onix Rolamentos", tempo = "2 anos", cargo = "Vendedor"},
                new CarreiraProfissional() {idCarreiraProfissional = 3, nomeEmpresa = "Contabilidade Arujo", tempo = "6 meses", cargo = "Contador"} 
            );

            modelBuilder.Entity<FormacaoAcademica>().HasData
            (
                new FormacaoAcademica() {idFormacaoAcademica = 1, IdGraduação = 1,  idCurso = "DS", idiomas = "Português nativo"},
                new FormacaoAcademica() {idFormacaoAcademica = 2, IdGraduação = "Nula",  idCurso = "DS", idiomas = "Português nativo, Inglês"},
                new FormacaoAcademica() {idFormacaoAcademica = 3, idGraduação = "ENGENHARIA DE SOFTWARE",  idCurso = "DS", idiomas = "Português nativo, Ingles"}
            );

            modelBuilder.Entity<Conhecimento>().HasData
            (
                new Conhecimento() {ConhecimentoId = 1, nomeConhecimento = "C#"},
                new Conhecimento() {ConhecimentoId = 2, nomeConhecimento = "Angular"},
                new Conhecimento() {ConhecimentoId = 3, nomeConhecimento = "Java"}
            );

            modelBuilder.Entity<Curso>().HasData
            (
                new Curso() {idCurso = 1, nomeCurso = "DS"},
                new Curso() {idCurso = 2, nomeCurso = "DS"},
                new Curso() {idCurso = 3, nomeCurso = "DS"}
            );

            modelBuilder.Entity<Graduacao>().HasData
            (
                new Graduacao() {idGraduacao = 1, nomeGraduacao = "MARKETING DIGITAL", inicioGraduacao = "02/2024", fimGraduacao = "12/2026"},
                new Graduacao() {idGraduacao = 2, nomeGraduacao = "NULA", inicioGraduacao = "00/0000", fimGraduacao = "00/0000"},
                new Graduacao() {idGraduacao = 3, nomeGraduacao = "ENGENHARIA DE SOFTWARE", inicioGraduacao = "02/2020", fimGraduacao = "12/2025"}

            );

            modelBuilder.Entity<CursoVaga>().HasNoKey();
            /*(
                new CursoVaga() {idCurso = 1, idVaga = 1},
                new CursoVaga() {idCurso = 2, idVaga = 2},
                new CursoVaga() {idCurso = 3, idVaga = 3}
            ); */

            modelBuilder.Entity<ConhecimentoVaga>().HasNoKey();
            /*(
                new ConhecimentoVaga() {idVaga = 1, idConhecimento = 1, idNivel = "Iniciante"},
                new ConhecimentoVaga() {idVaga = 2, idConhecimento = 1, idNivel = "Intermediário"},
                new ConhecimentoVaga() {idVaga = 3, idConhecimento = 1, idNivel = "Avançado"}
            );*/

            modelBuilder.Entity<Nivel>().HasData
            (
                new Nivel() {idNivel = 1, descricao = "Iniciando minhas habilidades"},
                new Nivel() {idNivel = 2, descricao = "Tenho noção e alguns projetos na linguagem citada"},
                new Nivel() {idNivel = 3, descricao = "Dominio na linguagem citada"}
            );

            modelBuilder.Entity<Empresa>().HasData
            (
                new Empresa() {idEmpresa = 1, cnpj = "11.111.111/0001-01", razaoSocial = "Santos Futebol Clube", nomeSocial = "Santos", qtdFuncionarios = 200, porte = "Grande", CEP = "02124040"},
                new Empresa() {idEmpresa = 2, cnpj = "22.222.222/0002-02", razaoSocial = "Encopel Rolamentos LTDA", nomeSocial = "Encopel", qtdFuncionarios = 100, porte = "Grande", CEP = "02124050"},
                new Empresa() {idEmpresa = 3, cnpj = "33.333.333/0003-03", razaoSocial = "MAGAZINE LUIZA S/A", nomeSocial = "MAGAZINE LUIZA", qtdFuncionarios = 1000, porte = "Grande", CEP = "02125030"}
            );

            modelBuilder.Entity<Porte>().HasData
            (
                new Porte() {idPorte = 1, descricao = "xxxxxx"},
                new Porte() {idPorte = 2, descricao = "yyyyyy"},
                new Porte() {idPorte = 3, descricao = "zzzzzz"}
            );
            modelBuilder.Entity<EnderecoEmpresa>().HasData
            (
                new EnderecoEmpresa() {idEndereco = 1, CEP = "02124050", endereco ="Rua Kaneda", numero = 426, complemento =  "1", bairro = "Jardim Japão", cidade = "Sao Paulo", uf = "sp"},
                new EnderecoEmpresa() {idEndereco = 2, CEP = "02124040", endereco ="Av Guilherme Couting", numero = 751, complemento =  "3", bairro = "Jardim Japão", cidade = "Sao Paulo", uf = "sp"},
                new EnderecoEmpresa() {idEndereco = 3, CEP = "02125030", endereco ="Rua Benedito", numero = 420, complemento =  "34B", bairro = "Parque Novo Mundo", cidade = "Sao Paulo", uf = "sp"}
            );

            modelBuilder.Entity<Vaga>().HasData
            (
                new Vaga() {idVaga = 1, idEmpresa = 1, cargo = "Analista de Sistemas", descricao = "xxxxx", inicioVigencia = "02/02/2024", finalVifencia = "02/12/2024", salario = "R$2500", cargaHoraria = 9, localidade = "SP", percAderencia = 10, situacaoVaga = "Ativa" },
                new Vaga() {idVaga = 2, idEmpresa = 2, cargo = "Desenvolvedor FrontEnd", descricao = "yyyyy", inicioVigencia = "03/03/2024", finalVifencia = "03/12/2024", salario = "R$3000", cargaHoraria = 9, localidade = "SP", percAderencia = 8, situacaoVaga = "Ativa" },
                new Vaga() {idVaga = 3, idEmpresa = 3, cargo = "Programador c#", descricao = "zzzzz", inicioVigencia = "04/04/2024", finalVifencia = "04/12/2024", salario = "R$3500", cargaHoraria = 9, localidade = "SP", percAderencia = 7, situacaoVaga = "Ativa" }
            );

            modelBuilder.Entity<SituacaoVaga>().HasData
            (
                new SituacaoVaga() {idSituacao = 1, descricaoSituacao = "xxxxx"},
                new SituacaoVaga() {idSituacao = 2, descricaoSituacao = "yyyyy"},
                new SituacaoVaga() {idSituacao = 3, descricaoSituacao = "zzzzz"}
            );

            modelBuilder.Entity<BeneficioVaga>().HasNoKey();
            /*(
                new BeneficioVaga() {idBeneficio = 1, idVaga = "1"},
                new BeneficioVaga() {idBeneficio = 2, idVaga = "2"},
                new BeneficioVaga() {idBeneficio = 3, idVaga = "3"}
            );*/

            modelBuilder.Entity<Beneficio>().HasData
            (
                new Beneficio() {idBeneficio = 1, nomeBeneficio = "Plano de Saude"},
                new Beneficio() {idBeneficio = 2, nomeBeneficio = "Academia"},
                new Beneficio() {idBeneficio = 3, nomeBeneficio = "Meia entrada em cinemas, shows e eventos"}
            );

        }














































        
    }
}