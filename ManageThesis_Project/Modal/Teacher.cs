using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageThesis_Project.Modal
{
    [Table("Teacher")]
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public ICollection<Thesis> Theses { get; set; }
        public ICollection<Communication> Communications { get; set; }
    }

}
