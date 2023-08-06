using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.EntityLayer.Concrete
{
    public class Video
    {
        public int VideoId { get; set; }
        public int CourseId{ get; set; }
        public string VideoUrl{ get; set; }
        public string VideoName{ get; set; }
        public Course Course { get; set; }

    }
}
