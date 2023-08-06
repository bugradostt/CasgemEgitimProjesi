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
    public class EfTeacherRepository:GenericRepositoriy<Teacher>, ITeacherDal
    {
        private readonly Context context;

        public EfTeacherRepository(Context context)
        {
            this.context = context;
        }

        public async Task<Teacher> GetTeacherByUsername(string username)
        {
           var t=await context.Teachers.FirstOrDefaultAsync(x=>x.TeacherUsername== username);
            return t;
        }
    }
}
