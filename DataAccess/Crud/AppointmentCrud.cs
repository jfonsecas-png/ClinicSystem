using DataAccess.Dao;
using DataAccess.Mappers;
using DTO;

namespace DataAccess.Crud
{
    public class AppointmentCrud : CrudFactory
    {
        AppointmentMapper _mapper;

        public AppointmentCrud()
        {
            _mapper = new AppointmentMapper();
            _sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass dto)
        {
            var operation = _mapper.GetCreateStatement(dto);
            _sqlDao!.ExecuteProcedure(operation);
        }

        public List<T> RetrieveAllByPatientId<T>(int patientId)
        {
            var operation = _mapper.GetRetrieveAllByPatientIdStatement(patientId);
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
        public override List<T> RetrieveAll<T>() => throw new NotImplementedException();
        public override List<T> RetrieveById<T>(int pId) => throw new NotImplementedException();
    }
}