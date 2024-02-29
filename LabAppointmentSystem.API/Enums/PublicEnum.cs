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

    public enum DoctorSpecialization
    {
        [Description("General Practitioner")]
        GeneralPractitioner,

        [Description("Cardiologist")]
        Cardiologist,

        [Description("Dermatologist")]
        Dermatologist,

        [Description("Pediatrician")]
        Pediatrician,

        [Description("Surgeon")]
        Surgeon,

        [Description("Neurologist")]
        Neurologist,

        [Description("Psychiatrist")]
        Psychiatrist,

        [Description("Orthopedician")]
        Orthopedician,

        [Description("Gynecologist")]
        Gynecologist,

        [Description("Urologist")]
        Urologist,

        [Description("Ophthalmologist")]
        Ophthalmologist,

        [Description("ENT Specialist")]
        ENT_Specialist,

        [Description("Oncologist")]
        Oncologist,

        [Description("Dentist")]
        Dentist,

        [Description("Radiologist")]
        Radiologist,

        [Description("Physiotherapist")]
        Physiotherapist,

        [Description("Psychologist")]
        Psychologist,

        [Description("Endocrinologist")]
        Endocrinologist,

        [Description("Infectious Disease Specialist")]
        InfectiousDiseaseSpecialist
    }
}
