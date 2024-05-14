using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageThesis_Project.Modal
{
    [Table("Point")]
    public class Point
    {
       

        public int PointId { get; set; }

        public float Scores { get; set; }
        public string Result { get; set; }



        [ForeignKey("Thesis")]
        public int? ThesisId { get; set; }
        public Thesis Thesis { get; set; }

    }
}
