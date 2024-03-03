using System.ComponentModel;

namespace LabAppointmentSystem.API.Enums
{
    public enum Gender
    {
        [Description("Male")]
        Male,
        [Description("Female")]
        Female,
        [Description("Other")]
        Other
    }

    public enum Status
    {
        [Description("Inactive")]
        Inactive,
        [Description("Active")]
        Active,
        [Description("Remove")]
        Remove,
    }

    public enum AppointmentStatus
    {
        Pending,
        Verified,
        Paid,
        Rejected,
        Cancel,
    }
}
