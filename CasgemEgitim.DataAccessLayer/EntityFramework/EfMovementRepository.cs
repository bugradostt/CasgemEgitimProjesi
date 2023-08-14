using CasgemEgitim.DataAccessLayer.Abstract;
using CasgemEgitim.DataAccessLayer.Concrete;
using CasgemEgitim.DataAccessLayer.Repositories;
using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.DataAccessLayer.EntityFramework
{
	public class EfMovementRepository : GenericRepositoriy<Movement>, IMovementDal
	{
		Context c = new Context();
		public bool GetCoursesByIdWithStudentId(int courseId, int studentId)
		{
			var value = c.Movements.Where(x => x.CourseId == courseId && x.StudentId == studentId).FirstOrDefault();
			if (value!= null)
			{
				return true;
			}
			return false;
		}
	}
}
