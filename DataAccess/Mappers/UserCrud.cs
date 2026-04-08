using DataAccess.Dao;
using DataAccess.Mappers;
using DTO;

namespace DataAccess.Crud
{
    public class UserCrud : CrudFactory
    {
        UserMapper _mapper;

        public UserCrud()
        {
            _mapper = new UserMapper();
            _sqlDao = SqlDao.GetInstance();
        }

        public User? Login(string username, string password)
        {
            var operation = _mapper.GetLoginStatement(username, password);
            var results = _sqlDao!.ExecuteProcedureWithQuery(operation);

            if (results.Count > 0)
            {
                return (User)_mapper.BuildObject(results[0]);
            }
            return null;
        }

        public override void Create(BaseClass dto) => throw new NotImplementedException();
        public override void Delete(BaseClass dto) => throw new NotImplementedException();
        public override void Update(BaseClass dto) => throw new NotImplementedException();
        public override List<T> RetrieveAll<T>() => throw new NotImplementedException();
        public override List<T> RetrieveById<T>(int pId) => throw new NotImplementedException();
    }
}