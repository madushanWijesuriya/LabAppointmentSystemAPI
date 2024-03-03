using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Mappers;
using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Repositories;
using LabAppointmentSystem.API.Services.Interfaces;

namespace LabAppointmentSystem.API.Services.Classes
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository TestRepository)
        {
            _testRepository = TestRepository;
        }

        public IQueryable<Test> GetAllTests()
        {
            var tests = _testRepository.GetAllTests();

            return tests
                .AsQueryable();
        }

        public void CreateTest(Test Test)
        {
            _testRepository.SaveTest(Test);
        }
    }
}
