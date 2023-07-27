using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemEgitim.EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string ContactPhone { get; set; }
        public string ContactAdress { get; set; }
        public string ContactMail { get; set; }
        public string ContactMaps { get; set; }
    }
}
