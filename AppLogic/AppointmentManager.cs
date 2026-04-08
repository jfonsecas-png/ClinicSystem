using DataAccess.Crud;
using DTO;

namespace AppLogic
{
    public interface IAppointmentManager
    {
        string CreateAppointment(Appointment appointment);
        List<Appointment> GetAppointmentsByPatientId(int patientId);
    }

    public class AppointmentManager : IAppointmentManager
    {
        public string CreateAppointment(Appointment appointment)
        {
            var crud = new AppointmentCrud();
            crud.Create(appointment);
            return "Cita registrada correctamente";
        }

        public List<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            var crud = new AppointmentCrud();
            return crud.RetrieveAllByPatientId<Appointment>(patientId);
        }
    }
}