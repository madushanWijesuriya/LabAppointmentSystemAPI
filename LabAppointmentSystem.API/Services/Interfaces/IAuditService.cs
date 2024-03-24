namespace LabAppointmentSystem.API.Services.Interfaces
{
    public interface IAuditService
    {
      void SetAuditFields<TEntity>(TEntity entity, string modifiedBy) where TEntity : class;
    }
}
