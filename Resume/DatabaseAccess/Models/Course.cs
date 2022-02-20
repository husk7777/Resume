using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.Models
{
    [Table("Course")]
    public partial class Course
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string School { get; set; }
        public string Qualification { get; set; }
        public bool Completed { get; set; }

        [ForeignKey("CandidateId")]
        public int CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CommencedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CompletionDate { get; set; }
    }
}
