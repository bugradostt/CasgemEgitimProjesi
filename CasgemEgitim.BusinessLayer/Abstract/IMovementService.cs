using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.BusinessLayer.Abstract
{
    public interface IMovementService : IGenericService<Movement>
    {
		public bool TGetCoursesByIdWithStudentId(int courseId, int studentId);
	}
}
