using CasgemEgitim.DataAccessLayer.Abstract;
using CasgemEgitim.DataAccessLayer.Concrete;
using CasgemEgitim.DataAccessLayer.Repositories;
using CasgemEgitim.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.DataAccessLayer.EntityFramework
{
    public class EfStudentRepository : GenericRepositoriy<Student>, IStudentDal
    {
        private readonly Context context;

        public EfStudentRepository(Context context)
        {
            this.context = context;
        }

        public async Task<Student> GetStudentByUsername(string username)
        {
            var s = await context.Students.FirstOrDefaultAsync(x => x.Username == username);
            return s;
        }
        public async Task<Student> AddStudent(Student student)
        {
            context.Students.Add(student);
            await context.SaveChangesAsync();
            return student;
        }
    }
}
