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
    public class TeacherManager : ITeacherService
    {
        readonly ITeacherDal _teacherDal;

        public TeacherManager(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }

        public void TDelete(Teacher t)
        {
            _teacherDal.Delete(t);
        }

        public Teacher TGetById(int id)
        {
            return _teacherDal.GetById(id);
        }

        public List<Teacher> TGetList()
        {
            return _teacherDal.GetList();
        }

        public async Task<Teacher> TGetTeacherByUsername(string username)
        {
            return await _teacherDal.GetTeacherByUsername(username);
        }

        public void TInsert(Teacher t)
        {
            _teacherDal.Insert(t);
        }

        public void TUpdate(Teacher t)
        {
            _teacherDal.Update(t);
        }
        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            return await _teacherDal.AddTeacher(teacher);
        }
    }
}
