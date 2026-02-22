using DTO;

namespace AppLogic
{
    public class PatientManager : IPatientManager
    {
        public List<Patient> GetAllPatients()
        {
            return new List<Patient>
            {
                new Patient { Id = 1, Name = "Daniel" },
                new Patient { Id = 2, Name = "Maria" },
                new Patient { Id = 3, Name = "Carlos" }
            };
        }

        public Patient GetPatientById(int id)
        {
            return new Patient { Id = id, Name = "Paciente " + id };
        }
    }
}