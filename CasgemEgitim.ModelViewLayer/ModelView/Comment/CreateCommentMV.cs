using CasgemEgitim.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.ModelViewLayer.ModelView.Comment
{
    public class CreateCommentMV
    {
       
        public int CourseId { get; set; }
        public string CommentMessage { get; set; }
        public int StudentId { get; set; }
        
    }
}
