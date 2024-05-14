    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Runtime.ConstrainedExecution;
    using System.Text;
    using System.Threading.Tasks;

    namespace ManageThesis_Project.Modal
    {
        [Table("Group")]
        public class Group
        {
            [Key]
            public int GroupId { get; set; }
            [Required]
            [MaxLength(100)]
            public string Name { get; set; }
           
            public int StudentSlot { get; set; }

            public ICollection<Student> Students { get; set; }


            public int? ThesisId { get; set; }
            [ForeignKey("ThesisId")]
            public Thesis Thesis { get; set; }


            public ICollection<Task> Tasks { get; set; }


      
    }
    }
