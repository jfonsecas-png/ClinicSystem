using DataAccess.Dao;
using DataAccess.Mappers;
using DTO;

namespace DataAccess.Crud
{
    public class PatientCrud : CrudFactory
    {
        PatientMapper _mapper;

        public PatientCrud()
        {
            _mapper = new PatientMapper();
            _sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass dto)
        {
            var operation = _mapper.GetCreateStatement(dto);
            _sqlDao!.ExecuteProcedure(operation);
        }

        public override List<T> RetrieveAll<T>()
        {
            var operation = _mapper.GetRetrieveAllStatement();
            var results = _sqlDao!.ExecuteProcedureWithQuery(operation);

            var resultList = new List<T>();
            if (results.Count > 0)
            {
                var dtoList = _mapper.BuildObjects(results);
                foreach (var item in dtoList)
                {
                    resultList.Add((T)Convert.ChangeType(item, typeof(T)));
                }
            }
            return resultList;
        }

        public override void Delete(BaseClass dto) => throw new NotImplementedException();
        public override void Update(BaseClass dto) => throw new NotImplementedException();
        public override List<T> RetrieveById<T>(int pId) => throw new NotImplementedException();
    }
}