using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageThesis_Project.Modal
{
    [Table("Task")]
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set;}
        public int? TaskPoint {  get; set; }

        public int? ThesisId { get; set; }
        [ForeignKey("ThesisId")]

        public Thesis Thesis { get; set; }

        public int? GroupId { get; set; }
        [ForeignKey("GroupId")]

        public Group Group { get; set; }


    }

}
