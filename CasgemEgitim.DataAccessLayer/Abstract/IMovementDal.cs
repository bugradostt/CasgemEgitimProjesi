using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.DataAccessLayer.Abstract
{
    public interface IMovementDal : IGenericDal<Movement>
    {
		public bool GetCoursesByIdWithStudentId(int courseId, int studentId);
	}
}
