using DataAccess.Dao;
using DataAccess.Mappers.Interfaces;
using DTO;

namespace DataAccess.Mappers
{
    public class PatientMapper : ICrudStatements, IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var patient = new Patient();
            patient.Id = int.Parse(row["Id"].ToString()!);
            patient.SocialSecurityId = row["SocialSecurityId"].ToString();
            patient.Name = row["Name"].ToString();
            patient.LastName = row["LastName"].ToString();
            patient.Email = row["Email"].ToString();
            patient.Address = row["Address"].ToString();
            patient.Birthday = DateTime.Parse(row["Birthday"].ToString()!);
            return patient;
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

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_GET_PATIENTS";
            return operation;
        }

        public SqlOperation GetCreateStatement(BaseClass dto)
        {
            var patient = (Patient)dto;
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_INSERT_PATIENT";
            operation.AddVarcharParam("socialSecurityId", patient.SocialSecurityId);
            operation.AddVarcharParam("name", patient.Name);
            operation.AddVarcharParam("lastName", patient.LastName);
            operation.AddVarcharParam("email", patient.Email);
            operation.AddVarcharParam("address", patient.Address);
            operation.AddDatetimeParam("birthday", patient.Birthday);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass dto) => throw new NotImplementedException();
        public SqlOperation GetUpdateStatement(BaseClass dto) => throw new NotImplementedException();
        public SqlOperation GetRetrieveByIdStatement(int pId) => throw new NotImplementedException();
    }
}