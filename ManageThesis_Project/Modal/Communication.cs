using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ManageThesis_Project.Modal
{
    [Table("Communication")]
    public class Communication
    {
        public int CommunicationId { get; set; }
        public string Message { get; set; } 
        public DateTime Timestamp { get; set; }


        [ForeignKey("Student")]
        public int? StudentId { get; set; }
        public Student Student { get; set; }


        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }



        [ForeignKey("Thesis")]
        public int? ThesisId { get; set; }
        public Thesis Thesis { get; set; }

    }
}
