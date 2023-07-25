﻿using CasgemEgitim.BusinessLayer.Abstract;
using CasgemEgitim.DataAccessLayer.Abstract;
using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.BusinessLayer.Concrete
{
    public class CourseManager : ICourseService
    {
        readonly ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public void TDelete(Course t)
        {
            _courseDal.Delete(t);
        }

        public Course TGetById(int id)
        {
            return _courseDal.GetById(id);
        }

        public List<Course> TGetList()
        {
            return _courseDal.GetList();
        }

        public void TInsert(Course t)
        {
            _courseDal.Insert(t);
        }

        public void TUpdate(Course t)
        {
           _courseDal.Update(t);
        }
    }
}
