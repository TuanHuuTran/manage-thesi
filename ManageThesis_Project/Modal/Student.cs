using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageThesis_Project.Modal
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Email { get; set;}
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string StudentCode { get; set; }

        public int? ThesisId { get; set; }
        [ForeignKey("ThesisId")]
        public Thesis Thesis { get; set; }

        public int? GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        public ICollection<Communication> Communications { get; set; }


    }
}
