using DataAccess.Crud;
using DTO;

namespace AppLogic
{
    public interface IPatientManager
    {
        List<Patient> GetAllPatients();
        Patient? GetPatientById(int id);
    }

    public class PatientManager : IPatientManager
    {
        public List<Patient> GetAllPatients()
        {
            var crud = new PatientCrud();
            return crud.RetrieveAll<Patient>();
        }

        public Patient? GetPatientById(int id)
        {
            var crud = new PatientCrud();
            var patients = crud.RetrieveAll<Patient>();
            return patients.FirstOrDefault(p => p.Id == id);
        }
    }
}