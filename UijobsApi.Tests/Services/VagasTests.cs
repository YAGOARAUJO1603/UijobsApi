using Moq;
using UijobsApi.DAL.Repositories.Vagas;
using UijobsApi.DAL.Unit_of_Work;
using UijobsApi.Exceptions;
using UijobsApi.Services.Vagas;
using UIJobsAPI.Exceptions;

namespace UijobsApi.Tests.Services
{
    [TestClass]
    public class VagasTests
    {
        private readonly Mock<IVagaRepository> _mockVagaRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly VagaService _vagaService;

        public VagasTests()
        {
            _mockVagaRepository = new Mock<IVagaRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _vagaService = new VagaService(_mockVagaRepository.Object, _mockUnitOfWork.Object);
        }

        #region Add Vaga
        [TestMethod]
        public async Task ShouldThrowABadRequestExceptionWhenWorkTimeExceedsLimitTime()
        {
            ushort cargaHorariaExcedida = 44;
            await Assert.ThrowsExceptionAsync<BadRequestException>(() => _vagaService.ValidarCargaHoraria(cargaHorariaExcedida));
        }

        [TestMethod]
        public void ShouldValidateWorkTimeLessThanForthy()
        {
            ushort cargaHorarioEstagio = 30;
            var cargaHoraria = _vagaService.ValidarCargaHoraria(cargaHorarioEstagio);
            Assert.AreEqual(cargaHoraria, null);
        }

        [TestMethod]
        public async Task ShouldThrowABadRequestExceptionWhenWorkTimeIsLessThanThirtyHours()
        {
            ushort cargaHorariaExcedida = 29;
            await Assert.ThrowsExceptionAsync<BadRequestException>(() => _vagaService.ValidarCargaHoraria(cargaHorariaExcedida));
        }

        #endregion
    }
}
