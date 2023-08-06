using CasgemEgitim.DataAccessLayer.Abstract;
using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.DataAccessLayer.Abstract
{
    public interface ITeacherDal:IGenericDal<Teacher>
    {
        Task<Teacher> GetTeacherByUsername(string username);
    }
}
