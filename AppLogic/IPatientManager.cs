using DTO;

namespace AppLogic
{
    public interface IPatientManager
    {
        List<Patient> GetAllPatients();
        Patient GetPatientById(int id);
    }
}