using DataAccess.Dao;
using DataAccess.Mappers.Interfaces;
using DTO;

namespace DataAccess.Mappers
{
    public class AppointmentMapper : ICrudStatements, IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var appointment = new Appointment();
            appointment.Id = int.Parse(row["Id"].ToString()!);
            appointment.PatientId = int.Parse(row["PatientId"].ToString()!);
            appointment.Title = row["Title"].ToString();
            appointment.Speciality = row["Speciality"].ToString();
            appointment.AppointmentDate = DateTime.Parse(row["AppointmentDate"].ToString()!);
            return appointment;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> rows)
        {
            var results = new List<BaseClass>();
            foreach (var row in rows)
            {
                results.Add(BuildObject(row));
            }
            return results;
        }

        public SqlOperation GetCreateStatement(BaseClass dto)
        {
            var appointment = (Appointment)dto;
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_INSERT_APPOINTMENT";
            operation.AddIntParam("patientId", appointment.PatientId);
            operation.AddDatetimeParam("date", appointment.AppointmentDate);
            operation.AddVarcharParam("title", appointment.Title);
            operation.AddVarcharParam("specialty", appointment.Speciality);
            return operation;
        }

        public SqlOperation GetRetrieveAllByPatientIdStatement(int patientId)
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_GET_APPOINTMENTS_BY_PATIENT_ID";
            operation.AddIntParam("patientId", patientId);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass dto) => throw new NotImplementedException();
        public SqlOperation GetUpdateStatement(BaseClass dto) => throw new NotImplementedException();
        public SqlOperation GetRetrieveAllStatement() => throw new NotImplementedException();
        public SqlOperation GetRetrieveByIdStatement(int pId) => throw new NotImplementedException();
    }
}