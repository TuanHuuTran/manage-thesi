using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageThesis_Project.Modal
{
    [Table("Thesis")]
    public class Thesis
    {
        [Key]
        public int ThesisId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }
        public string Gener { get; set; }
        [Required]
        [MaxLength(100)]
        public string Teachnology { get; set; }
        public string Requirement { get; set; }
        [Range(2, 4)]
        public int NumberofStudent { get; set; }

        public int? TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }

        public ICollection<Student> Students { get; set; }


        public ICollection<Group> Groups { get; set; }


        public ICollection<Task> Tasks { get; set; }

        public ICollection<Communication> Communications { get; set; }

        public ICollection<Point> Points { get; set; }

    }
}
