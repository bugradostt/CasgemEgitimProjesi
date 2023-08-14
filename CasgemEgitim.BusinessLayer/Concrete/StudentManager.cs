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
    public class StudentManager : IStudentService
    {
        private readonly IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public async Task<Student> TGetStudentByUsername(string username)
        {
            return await _studentDal.GetStudentByUsername(username);
        }

        public void TDelete(Student t)
        {
            _studentDal.Delete(t);
        }

        public Student TGetById(int id)
        {
           return _studentDal.GetById(id);
        }

        public List<Student> TGetList()
        {
            return _studentDal.GetList();
        }

        public void TInsert(Student t)
        {
            _studentDal.Insert(t);
        }

        public void TUpdate(Student t)
        {
            _studentDal.Update(t);
        }
        public async Task<Student> AddStudent(Student student)
        {
            return await _studentDal.AddStudent(student);
        }
    }
}
