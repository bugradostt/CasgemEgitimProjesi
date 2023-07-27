using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.EntityLayer.Concrete
{
    public class Teacher
    {
        [Key]
        public int TeachertId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public string TeacherUsername { get; set; }
        public string TeacherPassword { get; set; }
        public string TeacherImageUrl { get; set; }

    }
}
