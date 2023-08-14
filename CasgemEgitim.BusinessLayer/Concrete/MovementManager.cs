using CasgemEgitim.BusinessLayer.Abstract;
using CasgemEgitim.DataAccessLayer.Abstract;
using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.BusinessLayer.Concrete
{
    public class MovementManager : IMovementService
    {
        IMovementDal _movementDal;

        public MovementManager(IMovementDal movementDal)
        {
            _movementDal = movementDal;
        }

        public void TDelete(Movement t)
        {
            throw new NotImplementedException();
        }

        public Movement TGetById(int id)
        {
            throw new NotImplementedException();
        }

		public bool TGetCoursesByIdWithStudentId(int courseId, int studentId)
		{
			return _movementDal.GetCoursesByIdWithStudentId(courseId, studentId);
		}

		public List<Movement> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(Movement t)
        {
           _movementDal.Insert(t);
        }

        public void TUpdate(Movement t)
        {
            throw new NotImplementedException();
        }
    }
}
