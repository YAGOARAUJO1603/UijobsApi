using Microsoft.EntityFrameworkCore;
using UIJobsAPI.Models;

namespace UIJobsAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Beneficio> Beneficio { get; set; }
        public DbSet<BeneficioVaga> BeneficioVagas { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<SituacaoVaga> SituacaoVaga { get; set; }
        public DbSet<VagaIdioma> VagasIdiomas { get; set; }
        public DbSet<VagaConhecimento> VagasConhecimentos { get; set; }
        public DbSet<VagaCandidato> VagasCandidato { get; set; }
        public DbSet<Conhecimento> Conhecimentos { get; set; }
        public DbSet<Nivel> Nivel { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<CurriculoIdioma> CurriculoIdiomas { get; set; }
        public DbSet<CurriculoConhecimento> CurriculoConhecimentos { get; set; }
        public DbSet<Curriculo> Curriculo { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<FormacaoAcademica> FormacaoAcademica { get; set; }
        public DbSet<CarreiraProfissional> CarreiraProfissional { get; set; }
        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<EnderecoCandidato> EnderecoCandidato { get; set; }
        public DbSet<Escolaridade> Escolaridade { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<EnderecoEmpresa> EnderecoEmpresa { get; set; }
        public DbSet<Porte> Portes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // MapeamentoBeneficioVaga
            modelBuilder.Entity<BeneficioVaga>()
                .HasKey(bv => new { bv.idVagas, bv.idBeneficio });

            modelBuilder.Entity<BeneficioVaga>()
                .HasOne(bv => bv.Beneficio)
                .WithMany()
                .HasForeignKey(bv => bv.idBeneficio);

            modelBuilder.Entity<BeneficioVaga>()
                .HasOne(bv => bv.Vagas)
                .WithMany()
                .HasForeignKey(bv => bv.idVagas);

            // Mapeamento CarreiraProfissional
            modelBuilder.Entity<CarreiraProfissional>()
                .HasOne(c => c.Curriculo)
                .WithMany()
                .HasForeignKey(c => c.idCurriculo);


            // Mapeamento Curriculo
            modelBuilder.Entity<Curriculo>()
                .HasOne(c => c.Candidato)
                .WithMany()
                .HasForeignKey(c => c.idCandidato);
            modelBuilder.Entity<Curriculo>()
                .HasOne(c => c.Escolaridade)
                .WithMany()
                .HasForeignKey(c => c.idEscolaridade);

            // Mapeamento CurriculoConhecimento
            modelBuilder.Entity<CurriculoConhecimento>()
                .HasOne(c => c.Curriculo)
                .WithMany()
                .HasForeignKey(c => c.idCurriculo);

            modelBuilder.Entity<CurriculoConhecimento>()
                .HasOne(c => c.Conhecimentos)
                .WithMany()
                .HasForeignKey(c => c.idConhecimentos);

            // Mapeamento CurriculoIdioma
            modelBuilder.Entity<CurriculoIdioma>()
                .HasOne(c => c.Curriculo)
                .WithMany()
                .HasForeignKey(c => c.idCurriculo);

            modelBuilder.Entity<CurriculoIdioma>()
                .HasOne(c => c.Idiomas)
                .WithMany()
                .HasForeignKey(c => c.idIdiomas);

            // Mapeamento Empresa
            modelBuilder.Entity<Empresa>()
                .HasOne(e => e.Porte)
                .WithMany()
                .HasForeignKey(e => e.idPortes);

            // Mapeamento EnderecoCandidato
            modelBuilder.Entity<EnderecoCandidato>()
                .HasOne(e => e.Candidato)
                .WithMany()
                .HasForeignKey(e => e.idCandidato);

            // Mapeamento EnderecoEmpresa
            modelBuilder.Entity<EnderecoEmpresa>()
                .HasOne(e => e.Empresa)
                .WithMany()
                .HasForeignKey(e => e.idEmpresa);

            // Mapeamento FormacaoAcademica
            modelBuilder.Entity<FormacaoAcademica>()
                .HasOne(f => f.Curso)
                .WithMany()
                .HasForeignKey(f => f.idCursos);

            modelBuilder.Entity<FormacaoAcademica>()
                .HasOne(f => f.Curriculo)
                .WithMany()
                .HasForeignKey(c => c.idCurriculo);

            // Mapeamento Vaga
            modelBuilder.Entity<Vaga>()
                .HasOne(v => v.Empresa)
                .WithMany()
                .HasForeignKey(v => v.idEmpresa);

            modelBuilder.Entity<Vaga>()
                .HasOne(v => v.SituacaoVaga)
                .WithMany()
                .HasForeignKey(v => v.idSituacaoVaga);

            modelBuilder.Entity<Vaga>()
                .HasOne(v => v.Escolaridade)
                .WithMany()
                .HasForeignKey(v => v.idEscolaridade);

            // Mapeamento VagaCandidato
            modelBuilder.Entity<VagaCandidato>()
                .HasOne(v => v.Vagas)
                .WithMany()
                .HasForeignKey(v => v.idVagas);

            // Mapeamento VagaConhecimento
            modelBuilder.Entity<VagaConhecimento>()
                .HasOne(v => v.Vagas)
                .WithMany()
                .HasForeignKey(v => v.idVagas);

            modelBuilder.Entity<VagaConhecimento>()
                .HasOne(v => v.Nivel)
                .WithMany()
                .HasForeignKey(v => v.idNivel);

            modelBuilder.Entity<VagaConhecimento>()
                .HasOne(v => v.Conhecimentos)
                .WithMany()
                .HasForeignKey(v => v.idConhecimentos);

            // Mapeamento VagaIdioma
            modelBuilder.Entity<VagaIdioma>()
                .HasOne(v => v.Vagas)
                .WithMany()
                .HasForeignKey(v => v.idVagas);

            modelBuilder.Entity<VagaIdioma>()
                .HasOne(v => v.Idioma)
                .WithMany()
                .HasForeignKey(v => v.idIdiomas);
        }
    }
}
