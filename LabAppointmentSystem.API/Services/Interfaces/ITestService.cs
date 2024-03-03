using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Services.Interfaces
{
    public interface ITestService
    {
        IQueryable<Test> GetAllTests();
        void CreateTest(Test TestDto);
    }
}
