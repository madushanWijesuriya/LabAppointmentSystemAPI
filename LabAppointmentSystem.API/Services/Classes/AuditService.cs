using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Services.Interfaces;

namespace LabAppointmentSystem.API.Services.Classes
{
    public class AuditService : IAuditService
    {
        public void SetAuditFields<TEntity>(TEntity entity, string modifiedBy) where TEntity : class
        {
            var now = DateTime.UtcNow;

            if (entity is IAuditable auditableEntity)
            {
                auditableEntity.CreatedAt = auditableEntity.CreatedAt == default ? now : auditableEntity.CreatedAt;
                auditableEntity.UpdatedAt = now;
                auditableEntity.ModifiedBy = modifiedBy;
            }
        }
    }
}
