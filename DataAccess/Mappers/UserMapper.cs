using DataAccess.Dao;
using DataAccess.Mappers.Interfaces;
using DTO;

namespace DataAccess.Mappers
{
    public class UserMapper : ICrudStatements, IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var user = new User();
            user.Id = int.Parse(row["Id"].ToString()!);
            user.Username = row["Username"].ToString();
            user.Role = row["Role"].ToString();
            user.PatientId = row["PatientId"] == DBNull.Value
                ? null
                : int.Parse(row["PatientId"].ToString()!);
            return user;
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

        public SqlOperation GetLoginStatement(string username, string password)
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "SP_LOGIN";
            operation.AddVarcharParam("username", username);
            operation.AddVarcharParam("password", password);
            return operation;
        }

        public SqlOperation GetCreateStatement(BaseClass dto) => throw new NotImplementedException();
        public SqlOperation GetDeleteStatement(BaseClass dto) => throw new NotImplementedException();
        public SqlOperation GetUpdateStatement(BaseClass dto) => throw new NotImplementedException();
        public SqlOperation GetRetrieveAllStatement() => throw new NotImplementedException();
        public SqlOperation GetRetrieveByIdStatement(int pId) => throw new NotImplementedException();
    }
}